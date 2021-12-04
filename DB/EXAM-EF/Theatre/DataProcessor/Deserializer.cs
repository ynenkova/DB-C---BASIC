namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportPlaysDto[]), new XmlRootAttribute("Plays"));
            var listPlays = (ImportPlaysDto[])serializer.Deserialize(new StringReader(xmlString));
            var list = new List<Play>();
            var sb = new StringBuilder();
            foreach (var pl in listPlays)
            {
                if (!IsValid(pl))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                TimeSpan date;
                bool isDate = TimeSpan.TryParseExact(pl.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out date);
                if (date.TotalHours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<string> genre = new List<string>
                {
                    "Drama",
                      "Comedy",
                     "Romance",
                     "Musical"
                };
                if (!genre.Contains(pl.Genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var play = new Play()
                {
                    Title = pl.Title,
                    Duration = date,
                    Rating = pl.Rating,
                    Genre = Enum.Parse<Genre>(pl.Genre),
                    Description = pl.Description,
                    Screenwriter = pl.Screenwriter
                };
                list.Add(play);
                sb.AppendLine(String.Format(SuccessfulImportPlay, pl.Title, pl.Genre, pl.Rating));
            }
            context.Plays.AddRange(list);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportCastDto[]), new XmlRootAttribute("Casts"));
            var listCasts = (ImportCastDto[])serializer.Deserialize(new StringReader(xmlString));
            var list = new List<Cast>();
            var sb = new StringBuilder();
            foreach (var cas in listCasts)
            {
                if (!IsValid(cas))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast()
                {
                    FullName = cas.FullName,
                    IsMainCharacter = cas.IsMainCharacter,
                    PhoneNumber = cas.PhoneNumber,
                    PlayId = cas.PlayId
                };


                list.Add(cast);
                if (cas.IsMainCharacter == true)
                {
                    sb.AppendLine(String.Format(SuccessfulImportActor, cas.FullName, "main"));
                }
                else
                {
                    sb.AppendLine(String.Format(SuccessfulImportActor, cas.FullName, "lesser"));
                }

            }
            context.Casts.AddRange(list);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var json = JsonConvert.DeserializeObject<IEnumerable<ImportProjectionsDto>>(jsonString);
            var list = new List<Theatre>();
            var sb = new StringBuilder();
            foreach (var teo in json)
            {
                if (!IsValid(teo))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var theatre = new Theatre()
                {
                    Name = teo.Name,
                    NumberOfHalls = teo.NumberOfHalls,
                    Director = teo.Director
                };

                foreach (var ti in teo.Tickets)
                {
                    if (!IsValid(ti))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    theatre.Tickets.Add(new Ticket
                    {
                        Price = ti.Price,
                        RowNumber = ti.RowNumber,
                        PlayId = ti.PlayId
                    });
                }
                list.Add(theatre);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }
            context.Theatres.AddRange(list);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}

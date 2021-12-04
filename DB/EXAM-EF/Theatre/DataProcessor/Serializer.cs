namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context.Theatres.OrderByDescending(x=>x.NumberOfHalls).ThenBy(x=>x.Name).ToList().Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                 .Select(x => new ExportTopTheatersDto()
                 {
                     Name = x.Name,
                     Halls = x.NumberOfHalls,
                     TotalIncome = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                     Tickets = x.Tickets.ToList().Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                     .Select(t => new ExportTickets()
                     {
                         Price = t.Price,
                         RowNumber = t.RowNumber
                     }).OrderByDescending(t => t.Price).ToList()
                 }).ToList();
            var json = JsonConvert.SerializeObject(theaters, Formatting.Indented);
            return json;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            StringBuilder sb = new StringBuilder();

            var plays = context.Plays.OrderBy(x => x.Title).ThenByDescending(x => x.Genre).ToArray().Where(x => x.Rating <= rating).Select(x => new ExportPlaysDto
            {
                Title = x.Title,
                Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture),
                Rating = x.Rating > 0 ? x.Rating.ToString() : "Premier",
                Genre = x.Genre.ToString(),
                Actors = x.Casts.OrderByDescending(x => x.FullName).ToArray().Where(a => a.IsMainCharacter ==true).Select(a => new ExportActor
                {
                    FullName = a.FullName,
                    MainCharacter = $"Plays main character in '{x.Title}'."
                }).ToArray()
            }).ToArray();
            var xmlSerializer = new XmlSerializer(typeof(ExportPlaysDto[]), new XmlRootAttribute("Plays"));
            xmlSerializer.Serialize(new StringWriter(sb), plays, ns);
            return sb.ToString().TrimEnd();
        }
       
    }
}

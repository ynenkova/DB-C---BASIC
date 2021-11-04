namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            var result = ExportAlbumsInfo(context, 9);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {

            var albums = context.Producers
                .FirstOrDefault(x => x.Id == producerId)
                .Albums
                .Select(album => new
                {
                    AlbumName = album.Name,
                    ReleaseDate = album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = album.Producer.Name,
                    Songs = album.Songs.Select(song => new
                    {
                        SongName = song.Name,
                        Price = song.Price,
                        Writer = song.Writer.Name,

                    })
                        .OrderByDescending(y => y.SongName)
                        .ThenBy(y => y.Writer)
                        .ToList(),
                    AlbumPrice = album.Price
                })
                .OrderByDescending(x => x.AlbumPrice)
                .ToList();
           
            var sb = new StringBuilder();

    
            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");
                var count = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{count++}")
                          .AppendLine($"---SongName: {song.SongName}")
                          .AppendLine($"---Price: {song.Price:F2}")
                          .AppendLine($"---Writer: {song.Writer}");
                    
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}

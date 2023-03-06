namespace MusicHub;

using System;
using System.Globalization;
using System.Text;

using Data;

public class StartUp
{
    public static void Main()
    {
        MusicHubDbContext context =
            new MusicHubDbContext();

        //string albumsInfo = ExportAlbumsInfo(context, 9);
        //Console.WriteLine(albumsInfo);

        string songs = ExportSongsAboveDuration(context, 4);
        Console.WriteLine(songs);

    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        StringBuilder sb = new StringBuilder();

        var albumsInfo = context.Albums
            .Where(a => a.ProducerId.HasValue &&
                        a.ProducerId.Value == producerId)
            .ToArray()
            .OrderByDescending(a => a.Price)
            .Select(a => new
            {
                a.Name,
                ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                ProducerName = a.Producer.Name,
                Songs = a.Songs
                .Select(s => new
                {
                    s.Name,
                    Price = s.Price.ToString("f2"),
                    WriterName = s.Writer.Name
                })
                .OrderByDescending(s => s.Name)
                .ThenBy(s => s.WriterName),
                Price = a.Price.ToString("f2")
            })
            .ToArray();


        foreach (var album in albumsInfo)
        {
            sb
                .AppendLine($"-AlbumName: {album.Name}")
                .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                .AppendLine($"-ProducerName: {album.ProducerName}")
                .AppendLine("-Songs:");

            int currentSongNum = 1;

            foreach (var song in album.Songs)
            {
                sb
                    .AppendLine($"---#{currentSongNum}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Price: {song.Price}")
                    .AppendLine($"---Writer: {song.WriterName}");

                currentSongNum++;
            }

            sb.AppendLine($"-AlbumPrice: {album.Price}");
        }

        return sb.ToString().TrimEnd();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {
        StringBuilder sb = new StringBuilder();

        var songsInfo = context.Songs
            .AsEnumerable()
            .Where(s => s.Duration.TotalSeconds > duration)
            .Select(s => new
            {
                s.Name,
                Performers = s.SongPerformers
                .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                .OrderBy(p => p)
                .ToArray(),
                WriterName = s.Writer.Name,
                ProducerName = s.Album.Producer.Name,
                Duration = s.Duration.ToString("c")
            })
            .OrderBy(s => s.Name)
            .ThenBy(s => s.WriterName)
            .ToArray();

        int songNum = 1;

        foreach (var song in songsInfo)
        {
            sb
                .AppendLine($"-Song #{songNum}")
                .AppendLine($"---SongName: {song.Name}")
                .AppendLine($"---Writer: {song.WriterName}");

            foreach (var performer in song.Performers)
            {
                sb.AppendLine($"---Performer: {performer}");
            }

            sb
                .AppendLine($"---AlbumProducer: {song.ProducerName}")
                .AppendLine($"---Duration: {song.Duration}");

            songNum++;
        }

        return sb.ToString().TrimEnd();
    }
}

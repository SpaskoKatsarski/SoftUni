namespace MusicHub;

using Data;

public class StartUp
{
    static void Main(string[] args)
    {
        var context = new MusicHubDbContext();
        Console.WriteLine("Connected");
    }
}
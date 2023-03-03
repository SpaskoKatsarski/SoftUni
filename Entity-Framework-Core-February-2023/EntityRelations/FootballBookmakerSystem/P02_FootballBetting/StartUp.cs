namespace P02_FootballBetting;

using Data;

public class StartUp
{
    static void Main(string[] args)
    {
        FootballBettingContext context = new FootballBettingContext();
        Console.WriteLine("Connected!");
    }
}
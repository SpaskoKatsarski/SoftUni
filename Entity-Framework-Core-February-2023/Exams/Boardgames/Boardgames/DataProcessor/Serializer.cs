namespace Boardgames.DataProcessor
{
    using Newtonsoft.Json;

    using Data;
    using Utilities;
    using ExportDto;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportCreatorDto[] creators = context.Creators
                .Where(c => c.Boardgames.Count >= 1)
                .ToArray()
                .Select(c => new ExportCreatorDto()
                {
                    Name = $"{c.FirstName} {c.LastName}",
                    BoardgamesCount = c.Boardgames.Count,
                    Boardgames = c.Boardgames
                    .Select(b => new ExportBoardgameDto()
                    {
                        Name = b.Name,
                        YearPublished = b.YearPublished
                    })
                    .OrderBy(b => b.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.Boardgames.Length)
                .ThenBy(c => c.Name)
                .ToArray();

            return xmlHelper.Serialize(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year
                                                          && bs.Boardgame.Rating <= rating))
                .ToArray()
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(bs => bs.Boardgame.YearPublished >= year
                                 && bs.Boardgame.Rating <= rating)
                    .Select(bs => new
                    {
                        bs.Boardgame.Name,
                        bs.Boardgame.Rating,
                        bs.Boardgame.Mechanics,
                        Category = bs.Boardgame.CategoryType.ToString()
                    })
                    .OrderByDescending(b => b.Rating)
                    .ThenBy(b => b.Name)
                    .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Count())
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}
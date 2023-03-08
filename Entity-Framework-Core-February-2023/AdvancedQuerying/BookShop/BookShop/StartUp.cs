namespace BookShop;

using System.Linq;
using System.Text;

using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);

        string result = GetMostRecentBooks(db);
        Console.WriteLine(result);
    }

    // Problem 02
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        var books = context.Books
            .AsEnumerable()
            .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
            .Select(b => b.Title)
            .OrderBy(t => t);

        return String.Join(Environment.NewLine, books);
    }

    // Problem 03
    public static string GetGoldenBooks(BookShopContext context)
    {
        var books = context.Books
            .AsEnumerable()
            .Where(b => b.EditionType.ToString() == "Gold" &&
                   b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title);

        return String.Join(Environment.NewLine, books);
    }

    // Problem 04
    public static string GetBooksByPrice(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var books = context.Books
            .Where(b => b.Price > 40)
            .Select(b => new
            {
                b.Title,
                b.Price
            })
            .OrderByDescending(b => b.Price)
            .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 05
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        var books = context.Books
            .Where(b => b.ReleaseDate.HasValue &&
                   b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToList();

        return String.Join(Environment.NewLine, books);
    }

    // Problem 06
    public static string GetBooksByCategory(BookShopContext context, string categories)
    {
        string[] categoriesArr = categories
            .ToLower()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.ToLower())
            .ToArray();

        string[] bookTitles = context.Books
            .Where(b => b.BookCategories.Any(bc => categoriesArr.Contains(bc.Category.Name.ToLower())))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToArray();

        return String.Join(Environment.NewLine, bookTitles);
    }

    // Problem 07
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        StringBuilder sb = new StringBuilder();

        int[] dateArr = date
            .Split("-")
            .Select(x => int.Parse(x))
            .ToArray();

        int year = dateArr[2];
        int month = dateArr[1];
        int day = dateArr[0];

        var dateToCompare = new DateTime(year, month, day);

        var books = context.Books
            .Where(b => b.ReleaseDate.HasValue &&
                   b.ReleaseDate.Value.CompareTo(dateToCompare) < 0)
            .OrderByDescending(b => b.ReleaseDate.Value)
            .Select(b => new
            {
                b.Title,
                EditionType = b.EditionType.ToString(),
                b.Price
            })
            .ToArray();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 08
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        string[] authorsFullNames = context.Authors
            .AsEnumerable()
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => $"{a.FirstName} {a.LastName}")
            .OrderBy(a => a)
            .ToArray();

        return String.Join(Environment.NewLine, authorsFullNames);
    }

    // Problem 09
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        string[] titles = context.Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToArray();

        return String.Join(Environment.NewLine, titles);
    }

    // Problem 10
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        string[] result = context.Books
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
            .ToArray();

        return String.Join(Environment.NewLine, result);
    }

    // Problem 11
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        int count = context.Books
            .Count(b => b.Title.Length > lengthCheck);

        return count;
    }

    // Problem 12
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var authorsWithBookCopies = context.Authors
            .Select(a => new
            {
                Name = $"{a.FirstName} {a.LastName}",
                BookCopies = a.Books.Sum(b => b.Copies)
            })
            .OrderByDescending(bc => bc.BookCopies)
            .ToArray();

        foreach (var author in authorsWithBookCopies)
        {
            sb.AppendLine($"{author.Name} - {author.BookCopies}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 13
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var categoryProfitInfo = context.Categories
            .Select(c => new
            {
                CategoryName = c.Name,
                Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
            })
            .OrderByDescending(cpi => cpi.Profit)
            .ThenBy(cpi => cpi.CategoryName)
            .ToArray();

        foreach (var cpi in categoryProfitInfo)
        {
            sb.AppendLine($"{cpi.CategoryName} ${cpi.Profit:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 14 ?
    public static string GetMostRecentBooks(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var categories = context.Categories
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                CategoryName = c.Name,
                MostRecentBooks = c.CategoryBooks
                .OrderByDescending(cb => cb.Book.ReleaseDate.Value)
                .Take(3)
                .Select(cb => new
                {
                    cb.Book.Title,
                    ReleaseDate = cb.Book.ReleaseDate.Value.Year
                })
            })
            .ToArray();

        foreach (var category in categories)
        {
            sb.AppendLine($"--{category.CategoryName}");

            foreach (var book in category.MostRecentBooks)
            {
                sb.AppendLine($"{book.Title} ({book.ReleaseDate})");
            }
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 16
    public static int RemoveBooks(BookShopContext context)
    {
        var booksToRemove = context.Books.Where(b => b.Copies < 4200);
        context.Books.RemoveRange(booksToRemove);

        int affectedRows = context.SaveChanges();

        return affectedRows / 2;
    }
}



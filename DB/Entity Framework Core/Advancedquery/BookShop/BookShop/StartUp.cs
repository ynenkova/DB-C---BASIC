using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            Console.WriteLine(RemoveBooks(db));

        }
        //1.Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var books = context.Books.AsEnumerable()
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                                    .OrderBy(b => b)
                                    .ToList();
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book);
            }
            return string.Join(Environment.NewLine, books);
        }
        //2.Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books.AsEnumerable()
                .Where(b => b.EditionType.ToString() == "Gold" && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(x => x.Title).ToList();
            return String.Join(Environment.NewLine, books);
        }
        //3.	Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }
            return sb.ToString().TrimEnd();
        }
        //4.	Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,

                })
                .ToList();
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }
            return sb.ToString().TrimEnd();
        }
        //5.	Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var splitCategpry = input.Split().ToArray();

            var list = new List<string>();
            foreach (var item in splitCategpry)
            {
                var books = context.Books
               .Where(b => b.BookCategories.Any(x => x.Category.Name.ToLower().Equals(item.ToLower())))
               .Select(b => b.Title)
               .ToList();
                list.AddRange(books);
            }

            return String.Join(Environment.NewLine, list.OrderBy(x => x));
        }
        //6.	Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            var format = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books.Where(x => x.ReleaseDate.Value < format)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                }).ToList();
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }
            return sb.ToString().TrimEnd();
        }
        //7.	Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors.Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName).OrderBy(x => x).ToList();
            return String.Join(Environment.NewLine, authors);

        }
        //8.	Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books.Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();
            return String.Join(Environment.NewLine, books);
        }
        //9.	Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {

            var books = context.Books.Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    FullName = x.Author.FirstName + " " + x.Author.LastName,
                    x.Title,
                    x.BookId

                }).OrderBy(x => x.BookId).ToList();
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FullName})");
            }
            return sb.ToString().TrimEnd();
        }
        //10.	Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books.Where(x => x.Title.Length > lengthCheck).Select(x => x.Title).ToList();
            return books.Count();
        }
        //11.	Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {

            var count = context.Authors.Select(x => new
            {
                FullName = x.FirstName + " " + x.LastName,
                TotalBooksCopies = x.Books.Select(x => x.Copies).Sum()
            }).OrderByDescending(x => x.TotalBooksCopies).ToList();
            var sb = new StringBuilder();
            foreach (var item in count)
            {
                sb.AppendLine($"{item.FullName} - {item.TotalBooksCopies}");
            }
            return sb.ToString().TrimEnd();
        }
        //12.	Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {

            var books = context.Categories.Select(x => new
            {
                Category = x.Name,
                Profit = x.CategoryBooks.Select(x => x.Book.Price * x.Book.Copies).Sum()
            }).OrderByDescending(x => x.Profit).ThenBy(x => x.Category).ToList();
            var sb = new StringBuilder();
            foreach (var book in books)
            {

                sb.AppendLine($"{book.Category} ${book.Profit:F2}");
            }
            return sb.ToString().TrimEnd();
        }
        //13.	Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var category = context.Categories.Select(x => new
            {
                x.Name,
                Book = x.CategoryBooks.Select(x => new
                { x.Book.Title, x.Book.ReleaseDate }).OrderByDescending(x => x.ReleaseDate).Take(3)
                .ToList()
            }).OrderBy(x => x.Name).ToList();

            var sb = new StringBuilder();
            foreach (var cat in category)
            {
                sb.AppendLine($"--{cat.Name}");
                foreach (var item in cat.Book)
                {
                    sb.AppendLine($"{item.Title} ({item.ReleaseDate.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }
        //14.	Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            // Increase the prices of all books released before 2010 by 5.

            var price = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010);
            foreach (var p in price)
            {
                p.Price += 5;
            }

            context.SaveChanges();
        }
        //15.	Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Copies < 4200).ToList();
            var count = books.Count();
            context.Books.RemoveRange(books);
            context.SaveChanges();
            return count;
        }
    }
}

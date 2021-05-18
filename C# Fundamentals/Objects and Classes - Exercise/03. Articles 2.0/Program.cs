using System;
using System.Collections.Generic;
using System.Linq;
namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] splittedCommand = Console.ReadLine().Split(", ");
                string title = splittedCommand[0];
                string content = splittedCommand[1];
                string author = splittedCommand[2];
                var article = new Article(title, content, author);
                articles.Add(article);
            }
            string criteria = Console.ReadLine();

            if (criteria == "title")
            {
              articles=  articles.OrderBy(x => x.Title).ToList();
            }
            else if (criteria == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (criteria == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }
            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}

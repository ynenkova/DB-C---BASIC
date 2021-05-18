using System;
using System.Collections.Generic;
using System.Linq;
namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(", ");
            string title = text[0];
            string content = text[1];
            string author = text[2];
            Articles article = new Articles(title, content, author);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                string commandFirdt = command[0];
                if (commandFirdt == "Edit")
                {
                    string currentCon = command[1];
                    article.Edit(currentCon);
                }
                else if (commandFirdt == "ChangeAuthor")
                {
                    string currentAuth = command[1];
                    article.ChangeAuthor(currentAuth);
                }
                else if (commandFirdt == "Rename")
                {
                    string currentTit = command[1];
                    article.Rename(currentTit);
                }
            }
            Console.WriteLine(article);
        }
    }

    class Articles
    {
        public Articles(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }
        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}

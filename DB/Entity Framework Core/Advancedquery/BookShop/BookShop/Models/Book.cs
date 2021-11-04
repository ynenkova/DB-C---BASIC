﻿using BookShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Models
{
  public  class Book
    {
        public Book()
        {
            this.BookCategories = new HashSet<BookCategory>();
        }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int Copies { get; set; }
        public decimal Price { get; set; }
        public EditionType EditionType { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection< BookCategory> BookCategories { get; set; }

    }
}

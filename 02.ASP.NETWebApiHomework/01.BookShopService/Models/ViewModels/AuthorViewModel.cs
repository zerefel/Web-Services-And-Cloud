using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BookShop.Models;

namespace _01.BookShopService.Models.ViewModels
{
    public class AuthorViewModel
    {
        private ICollection<string> books;

        public AuthorViewModel(Author author)
        {
            this.books = new HashSet<string>();
            this.Id = author.Id;
            this.FirstName = author.FirstName;
            this.LastName = author.LastName;
            foreach (var book in author.Books)
            {
                this.BookTitles.Add(book.Title);
            }
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<string> BookTitles
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
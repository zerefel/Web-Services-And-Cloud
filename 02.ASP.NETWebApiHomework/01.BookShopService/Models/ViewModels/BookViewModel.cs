using System;
using System.Collections.Generic;
using BookShop.Models;

namespace _01.BookShopService.Models.ViewModels
{
    public class BookViewModel
    {
        private ICollection<string> categoryNames; 

        public BookViewModel(Book book)
        {
            this.categoryNames = new HashSet<string>();
            this.Id = book.Id;
            this.Title = book.Title;
            this.Description = book.Description;
            this.EditionType = book.EditionType;
            this.Price = book.Price;
            this.Copies = book.Copies;
            this.AuthorId = book.AuthorId;
            this.ReleaseDate = book.ReleaseDate;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EditionType EditionType { get; set; }
        public decimal Price { get; set; }
        public int Copies { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? AuthorId { get; set; }

        public ICollection<string> CategoryNames
        {
            get { return this.categoryNames; }
            set { this.categoryNames = value; }
        }
    }
}
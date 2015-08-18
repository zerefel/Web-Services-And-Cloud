using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Models;

namespace _01.BookShopService.Models.ViewModels
{
    public class SearchBookViewModel
    {
        public SearchBookViewModel(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
        }

        public int Id { get; set; }

        public string Title { get; set; }
    }
}
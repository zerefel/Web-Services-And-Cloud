using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Models;

namespace _01.BookShopService.Models.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
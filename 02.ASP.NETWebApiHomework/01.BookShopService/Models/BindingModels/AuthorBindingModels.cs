using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BookShop.Models;

namespace _01.BookShopService.Models.BindingModels
{
    public class AddAuthorBindingModel
    {
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _01.BookShopService.Models.BindingModels
{
    public class PutCategoryBindingModel
    {
        [Required]
        public string Name { get; set; }
    }

    public class AddCategoryBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BookShop.Models;

namespace _01.BookShopService.Models
{
    public class AddBookBindingModel
    {
        [MinLength(1, ErrorMessage = "Book title must be at least 1 characted long.")]
        [MaxLength(50, ErrorMessage = "Book title cannot be more than 50 characters long.")]
        [Required(ErrorMessage = "Book title is required.")]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public EditionType EditionType { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }
        
        public DateTime? ReleaseDate { get; set; }
    }

    public class PutBookBindingModel
    {
        [MinLength(1, ErrorMessage = "Book title must be at least 1 characted long.")]
        [MaxLength(50, ErrorMessage = "Book title cannot be more than 50 characters long.")]
        [Required(ErrorMessage = "Book title is required.")]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public EditionType EditionType { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
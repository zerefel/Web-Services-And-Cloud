using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Book
    {
        public Book()
        {
        }

        public Book(string title, string description, EditionType editionType, decimal price, int copies, DateTime? releaseDate)
        {
            this.Title = title;
            this.Description = description;
            this.EditionType = editionType;
            this.Price = price;
            this.Copies = copies;
            this.ReleaseDate = releaseDate;
        }

        public Book(int id, string title, string description, EditionType editionType, decimal price, int copies, DateTime? releaseDate, int authorId)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.EditionType = editionType;
            this.Price = price;
            this.Copies = copies;
            this.ReleaseDate = releaseDate;
            this.AuthorId = authorId;
        }

        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required]
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

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Category
    {
        public Category()
        {
        }

        public Category(string name)
        {
            this.Name = name;
        }

        public Category(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

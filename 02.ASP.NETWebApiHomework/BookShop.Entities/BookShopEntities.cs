using BookShop.Entities.Migrations;
using BookShop.Models;

namespace BookShop.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopEntities : DbContext
    {
        public BookShopEntities()
            : base("BookShopEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopEntities, Configuration>());
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}
using System.Globalization;
using System.IO;
using BookShop.Models;

namespace BookShop.Entities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShop.Entities.BookShopEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookShop.Entities.BookShopEntities context)
        {
            if (!context.Books.Any())
            {
                //using (var reader = new StreamReader("../../books.txt"))
                //{
                //    var line = reader.ReadLine();
                //    line = reader.ReadLine();

                //    while (line != null)
                //    {
                //        var data = line.Split(new[] { ' ' }, 6);
                //        var authorIndex = random.Next(0, authors.Count);
                //        var author = authors[authorIndex];
                //        var edition = (EditionType)int.Parse(data[0]);
                //        var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                //        var copies = int.Parse(data[2]);
                //        var price = decimal.Parse(data[3]);
                //        var title = data[5];

                //        context.Books.Add(new Book()
                //        {
                //            Author = author,
                //            EditionType = edition,
                //            ReleaseDate = releaseDate,
                //            Copies = copies,
                //            Price = price,
                //            Title = title
                //        });

                //        line = reader.ReadLine();
                //    }
                //}
            }
        }
    }
}
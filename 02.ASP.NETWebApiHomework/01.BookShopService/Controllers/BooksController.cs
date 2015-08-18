using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookShop.Models;
using BookShop.Entities;
using _01.BookShopService.Models;
using _01.BookShopService.Models.ViewModels;

namespace _01.BookShopService.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private BookShopEntities context = new BookShopEntities();

        [ResponseType(typeof(BookViewModel))]
        public IHttpActionResult GetBooks()
        {
            var books = context.Books.ToList();
            List<BookViewModel> booksViewModels = new List<BookViewModel>();

            foreach (var book in books)
            {
                booksViewModels.Add(new BookViewModel(book));
            }

            return this.Ok(booksViewModels);
        }

        [Route("{id}")]
        [ResponseType(typeof(BookViewModel))]
        public IHttpActionResult GetBook(int id)
        {
            var book = context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookViewModel = new BookViewModel(book);

            return this.Ok(bookViewModel);
        }

        [Route("{id}")]
        public IHttpActionResult PutBook(int id, [FromBody]PutBookBindingModel bookBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Author author = context.Authors.Find(bookBindingModel.AuthorId);

            if (author == null)
            {
                return BadRequest("No author with specified AuthorId.");
            }

            var book = new Book(id,
                bookBindingModel.Title,
                bookBindingModel.Description,
                bookBindingModel.EditionType,
                bookBindingModel.Price,
                bookBindingModel.Copies,
                bookBindingModel.ReleaseDate,
                author.Id);

            context.Entry(book).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook([FromBody]AddBookBindingModel bookBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Book book = new Book(bookBindingModel.Title, 
                bookBindingModel.Description, 
                bookBindingModel.EditionType, 
                bookBindingModel.Price,  
                bookBindingModel.Copies, 
                bookBindingModel.ReleaseDate);

            context.Books.Add(book);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        [Route("{id}")]
        [ResponseType(typeof(BookViewModel))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            context.Books.Remove(book);
            context.SaveChanges();

            var bookViewModel = new BookViewModel(book);

            return Ok(bookViewModel);
        }

        [HttpGet]
        [ResponseType(typeof (SearchBookViewModel))]
        public IHttpActionResult GetBookBySubstring([FromUri]string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return this.BadRequest("Please supply a search word.");
            }

            // TODO: Optimize the query to select only Title and Id
            var books = context.Books
                .Where(b => b.Title.Contains(word))
                .OrderBy(b => b.Title)
                .Take(10)
                .ToList();

            var viewModelBooks = new List<SearchBookViewModel>();

            foreach (var book in books)
            {
                viewModelBooks.Add(new SearchBookViewModel(book));
            }

            return this.Ok(viewModelBooks);
        }

        private bool BookExists(int id)
        {
            return context.Books.Count(e => e.Id == id) > 0;
        }
    }
}
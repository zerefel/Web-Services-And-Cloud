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
using _01.BookShopService.Models.BindingModels;
using _01.BookShopService.Models.ViewModels;

namespace _01.BookShopService.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private BookShopEntities context = new BookShopEntities();

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(AuthorViewModel))]
        public IHttpActionResult GetAuthor(int id)
        {
            Author author = context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            var authorViewModel = new AuthorViewModel(author);

            return Ok(authorViewModel);
        }

        [HttpPost]
        [ResponseType(typeof(AuthorViewModel))]
        public IHttpActionResult PostAuthor(AddAuthorBindingModel authorBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = new Author(authorBindingModel.FirstName, authorBindingModel.LastName);

            context.Authors.Add(author);
            context.SaveChanges();

            var authorViewModel = new AuthorViewModel(author);

            return CreatedAtRoute("DefaultApi", new { id = authorViewModel.Id }, authorViewModel);
        }

        [HttpGet]
        [Route("{id}/books")]
        [ResponseType(typeof(BookViewModel))]
        public IHttpActionResult GetAuthorBooks(int id)
        {
            if (!context.Authors.Any(a => a.Id == id))
            {
                return this.NotFound();
            }


            var authorBooks = context.Authors.Find(id).Books;
            var viewModelBooks = new List<BookViewModel>();

            foreach (var book in authorBooks)
            {
                viewModelBooks.Add(new BookViewModel(book));
            }

            return this.Ok(viewModelBooks);
        }
    }
}
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
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private BookShopEntities context = new BookShopEntities();

        [HttpGet]
        [ResponseType(typeof(CategoryViewModel))]
        public IHttpActionResult GetCategories()
        {
            var categories = context.Categories.ToList();

            var categoriesViewModels = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                categoriesViewModels.Add(new CategoryViewModel(category));
            }

            return this.Ok(categoriesViewModels);
        }

        [HttpGet]
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(new CategoryViewModel(category));
        }

        public IHttpActionResult PutCategory(int id, PutCategoryBindingModel categoryBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new Category(id, categoryBindingModel.Name);

            context.Entry(category).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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
        [ResponseType(typeof(CategoryViewModel))]
        public IHttpActionResult PostCategory([FromBody]AddCategoryBindingModel categoryBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new Category(categoryBindingModel.Name);

            context.Categories.Add(category);
            context.SaveChanges();

            var categoryViewModel = new CategoryViewModel(category);

            return CreatedAtRoute("DefaultApi", new { id = categoryViewModel.Id }, categoryViewModel);
        }

        [HttpDelete]
        [ResponseType(typeof(CategoryViewModel))]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            var categoryViewModel = new CategoryViewModel(category);

            return Ok(categoryViewModel);
        }

        private bool CategoryExists(int id)
        {
            return context.Categories.Count(e => e.Id == id) > 0;
        }
    }
}
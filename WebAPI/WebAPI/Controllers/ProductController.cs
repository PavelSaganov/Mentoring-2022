using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPI.EFRepository;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ApiContext apiContext;

        public ProductController(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        [HttpGet]
        public Products Read(int id)
        {
            return apiContext.Products.FirstOrDefault(c => c.CategoryID == id);
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<Products> GetAll()
        {
            return apiContext.Products.ToList();
        }

        [HttpPost]
        public OkResult Create(Products model)
        {
            model.ProductID = 0;
            apiContext.Products.Add(model);
            apiContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public OkResult Update(Products model)
        {
            apiContext.Products.Update(model);
            apiContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public OkResult Delete(int id)
        {
            var model = apiContext.Products.FirstOrDefault(c => c.ProductID == id);
            apiContext.Products.Remove(model);
            apiContext.SaveChanges();
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPI.EFRepository;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ApiContext apiContext;

        public CategoriesController(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        [HttpGet]
        public Categories Read(int id)
        {
            return apiContext.Categories.FirstOrDefault(c => c.CategoryID == id);
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<Categories> GetAll ()
        {
            return apiContext.Categories.ToList();
        }

        [HttpPost]
        public OkResult Create(string CategoryName, string Description)
        {
            var model = new Categories()
            {
                CategoryName = CategoryName,
                Description = Description,
            };

            apiContext.Categories.Add(model);
            apiContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public OkResult Update(Categories model)
        {
            apiContext.Categories.Update(model);
            apiContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public OkResult Delete(int id)
        {
            var model = apiContext.Categories.FirstOrDefault(c => c.CategoryID == id);
            apiContext.Categories.Remove(model);
            apiContext.SaveChanges();
            return Ok();
        }
    }
}

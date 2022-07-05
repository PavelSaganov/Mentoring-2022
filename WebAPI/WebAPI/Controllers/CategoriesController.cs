using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Read(int id)
        {
            return View(apiContext.Categories.FirstOrDefault(c => c.CategoryID == id));
        }

        [HttpPost]
        public ActionResult Create(Categories model)
        {
            apiContext.Categories.Add(model);
            apiContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(Categories model)
        {
            apiContext.Categories.Update(model);
            apiContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var model = apiContext.Categories.FirstOrDefault(c => c.CategoryID == id);
            apiContext.Categories.Remove(model);
            apiContext.SaveChanges();
            return Ok();
        }
    }
}

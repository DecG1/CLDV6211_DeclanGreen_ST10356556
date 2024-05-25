using Microsoft.AspNetCore.Mvc;
using Online_Store.Models;

namespace Online_Store.Controllers
{
    public class ProductController : Controller
    {
        public Table_2 prodtbl = new Table_2();



        [HttpPost]
        public IActionResult MyWork(Table_2 products)
        {
            var result2 = prodtbl.Insert_product(products);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult MyWork()
        {
            return View(prodtbl);
        }
    }
}

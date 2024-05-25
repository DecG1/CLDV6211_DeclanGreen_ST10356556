using Microsoft.AspNetCore.Mvc;
using Online_Store.Models;

namespace Online_Store.Controllers
{
    public class ProductDisplayController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }
    }
}

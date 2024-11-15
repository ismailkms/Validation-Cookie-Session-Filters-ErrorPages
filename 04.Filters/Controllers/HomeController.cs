using _04.Filters.Filters;
using _04.Filters.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _04.Filters.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCustomer()
        {
            //Filters => Bir action �al��madan �nce ya da �al��d�ktan sonra bir �eyler yapmam�z� sa�layan yap�lard�r.
            return View();
        }

        [HttpPost]
        [ValidFirstName]
        //Olu�turmu� oldu�umuz filter attribute'ni kullanmak istedi�imiz action �st�ne ekliyoruz.
        public IActionResult CreateCustomer(Customer customer)
        {
            return View();
        }

    }
}

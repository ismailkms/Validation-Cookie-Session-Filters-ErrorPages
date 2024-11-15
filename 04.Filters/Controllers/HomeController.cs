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
            //Filters => Bir action çalýþmadan önce ya da çalýþdýktan sonra bir þeyler yapmamýzý saðlayan yapýlardýr.
            return View();
        }

        [HttpPost]
        [ValidFirstName]
        //Oluþturmuþ olduðumuz filter attribute'ni kullanmak istediðimiz action üstüne ekliyoruz.
        public IActionResult CreateCustomer(Customer customer)
        {
            return View();
        }

    }
}

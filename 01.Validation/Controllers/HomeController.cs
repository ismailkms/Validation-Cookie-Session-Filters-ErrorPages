using _01.Validation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _01.Validation.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateModel customerCreateModel)
        {
            //ModelState.IsValid => Gelen sonuca göre ilgili validation iþleminin geçerli olup olmadaðýný anlayabiliriz. IsValid true ise þartlarýmý saðlýyor demektir, false ise saðlamýyor demektir.
            
            if(customerCreateModel.FirstName == "ismail")
            {
                ModelState.AddModelError("", "Bu kullanýcý önceden kayýt edilmiþ");
                //Özel validation oluþturuyoruz.
            }

            if (ModelState.IsValid)
            {
                return View();
            }

            return View();
        }

    }
}

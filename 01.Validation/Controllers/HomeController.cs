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
            //ModelState.IsValid => Gelen sonuca g�re ilgili validation i�leminin ge�erli olup olmada��n� anlayabiliriz. IsValid true ise �artlar�m� sa�l�yor demektir, false ise sa�lam�yor demektir.
            
            if(customerCreateModel.FirstName == "ismail")
            {
                ModelState.AddModelError("", "Bu kullan�c� �nceden kay�t edilmi�");
                //�zel validation olu�turuyoruz.
            }

            if (ModelState.IsValid)
            {
                return View();
            }

            return View();
        }

    }
}


using Microsoft.AspNetCore.Mvc;

namespace _03.Session.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //Session => Sunucu taraf�nda verilerimizi ta��mam�z� sa�layan yap�lard�r. Ba�ka controller �zerinden eri�ilebilir.
            //Kullanabilmek i�in Program.cs'e app.UseSession(); ve builder.Services.AddSession(); eklememiz gerekiyor.

            SetSession();
            ViewBag.Session = GetSession();

            return View();
        }

        private void SetSession()
        {
            HttpContext.Session.SetString("iak", "Session deneme");
        }

        private string GetSession()
        {
            return HttpContext.Session.GetString("iak");
        }

    }
}

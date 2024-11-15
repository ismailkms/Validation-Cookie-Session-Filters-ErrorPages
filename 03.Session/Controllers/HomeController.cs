
using Microsoft.AspNetCore.Mvc;

namespace _03.Session.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //Session => Sunucu tarafýnda verilerimizi taþýmamýzý saðlayan yapýlardýr. Baþka controller üzerinden eriþilebilir.
            //Kullanabilmek için Program.cs'e app.UseSession(); ve builder.Services.AddSession(); eklememiz gerekiyor.

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

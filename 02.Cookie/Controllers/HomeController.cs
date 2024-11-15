
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _02.Cookie.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //Cookie(�erez) => Kullan�c�lar�n taray�c�lar�nda veri tutmam�z� sa�layan yap�lard�r. Ba�ka controller �zerinden eri�ilebilir.

            SetCookie();
            ViewBag.Cookie = GetCookie();
            return View();
        }

        private void SetCookie()
        {
            //HttpContext response �zerinden a�a��da yazd���m�z gibi cookie'yi set'leyebiliriz.
            HttpContext.Response.Cookies.Append("iak", "Cookie deneme", new CookieOptions
            {
                Expires = DateTime.Now.AddDays(10),
                //Cookie'nin ilgili kullan�c�n�n taray�c�s�nda ne kadar s�re tutulaca��n� belirtir.

                HttpOnly = true,
                //True olursa JavaScript'te document.cookie yaz�ld���nda sizin cookie'nize ula��lamaz.

                SameSite = SameSiteMode.Strict
                //SameSiteMode enum'�na Strict denilirse sadece olu�turmu� oldu�unuz web sitesi kullanabilir(www.iak.com), Lax denilirse bu cookie d��ardaki sayfalarada a��l�r(Yani ba�ka sayfalar ya da bizim subdomain'imiz kullanabilir)(www.kai.com,www.admin.iak.com).
            });
        }

        private string GetCookie()
        {
            string cookieValue = string.Empty;

            //HttpContext request �zerinden a�a��da yazd���m�z gibi cookie'yi �ekebiliriz.
            HttpContext.Request.Cookies.TryGetValue("iak", out cookieValue);

            return cookieValue;
        }

    }
}

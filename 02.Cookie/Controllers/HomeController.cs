
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _02.Cookie.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //Cookie(Çerez) => Kullanýcýlarýn tarayýcýlarýnda veri tutmamýzý saðlayan yapýlardýr. Baþka controller üzerinden eriþilebilir.

            SetCookie();
            ViewBag.Cookie = GetCookie();
            return View();
        }

        private void SetCookie()
        {
            //HttpContext response üzerinden aþaðýda yazdýðýmýz gibi cookie'yi set'leyebiliriz.
            HttpContext.Response.Cookies.Append("iak", "Cookie deneme", new CookieOptions
            {
                Expires = DateTime.Now.AddDays(10),
                //Cookie'nin ilgili kullanýcýnýn tarayýcýsýnda ne kadar süre tutulacaðýný belirtir.

                HttpOnly = true,
                //True olursa JavaScript'te document.cookie yazýldýðýnda sizin cookie'nize ulaþýlamaz.

                SameSite = SameSiteMode.Strict
                //SameSiteMode enum'ýna Strict denilirse sadece oluþturmuþ olduðunuz web sitesi kullanabilir(www.iak.com), Lax denilirse bu cookie dýþardaki sayfalarada açýlýr(Yani baþka sayfalar ya da bizim subdomain'imiz kullanabilir)(www.kai.com,www.admin.iak.com).
            });
        }

        private string GetCookie()
        {
            string cookieValue = string.Empty;

            //HttpContext request üzerinden aþaðýda yazdýðýmýz gibi cookie'yi çekebiliriz.
            HttpContext.Request.Cookies.TryGetValue("iak", out cookieValue);

            return cookieValue;
        }

    }
}

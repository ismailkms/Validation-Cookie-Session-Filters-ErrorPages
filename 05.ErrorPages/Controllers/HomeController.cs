using _05.ErrorPages.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _05.ErrorPages.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Status(int? code)
        {
            //code'da dönen hatanýn statuscode'u geliyor.
            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //Ýlgili hataya bu þelide ulaþabiliyoruz.
            ViewBag.Error = exceptionHandlerPathFeature?.Error.Message;

            //Burada, hatanýn sebebini sonradan görebilmemiz için loglama yapmamýz gerekir ama yapmasakta hata sayfamýz doðru bir þekilde çalýþýr.
            var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");

            DirectoryInfo directoryInfo = new DirectoryInfo(logFolderPath);
            //Klasör var mý diye kontrol ediyoruz yoksa oluþturuyoruz.
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            //15/11/2024 16:21:15
            var logFileName = DateTime.Now.ToString();

            logFileName = logFileName.Replace(" ", "_");
            logFileName = logFileName.Replace(":", "-");
            logFileName = logFileName.Replace("/", "-");
            logFileName += ".txt";

            var logFilePath = Path.Combine(logFolderPath, logFileName);

            FileInfo fileInfo = new FileInfo(logFilePath);
            var writer = fileInfo.CreateText();

            writer.WriteLine($"Hatanýn Gerçekleþtiði Yer: {exceptionHandlerPathFeature.Path}");
            writer.WriteLine($"Hata Mesajý: {exceptionHandlerPathFeature.Error.Message}");

            writer.Close();

            return View();
        }

        public IActionResult Hata()
        {
            throw new System.Exception("Sistemsel bir hata oluþtu");
        }
    }
}

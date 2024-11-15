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
            //code'da d�nen hatan�n statuscode'u geliyor.
            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //�lgili hataya bu �elide ula�abiliyoruz.
            ViewBag.Error = exceptionHandlerPathFeature?.Error.Message;

            //Burada, hatan�n sebebini sonradan g�rebilmemiz i�in loglama yapmam�z gerekir ama yapmasakta hata sayfam�z do�ru bir �ekilde �al���r.
            var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");

            DirectoryInfo directoryInfo = new DirectoryInfo(logFolderPath);
            //Klas�r var m� diye kontrol ediyoruz yoksa olu�turuyoruz.
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

            writer.WriteLine($"Hatan�n Ger�ekle�ti�i Yer: {exceptionHandlerPathFeature.Path}");
            writer.WriteLine($"Hata Mesaj�: {exceptionHandlerPathFeature.Error.Message}");

            writer.Close();

            return View();
        }

        public IActionResult Hata()
        {
            throw new System.Exception("Sistemsel bir hata olu�tu");
        }
    }
}

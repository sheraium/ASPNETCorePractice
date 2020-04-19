using System.Collections.Generic;
using System.IO;
using HowToUpload.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HowToUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private string _dir;

        public HomeController(IWebHostEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }

        public IActionResult FileInModel(SomeForm someForm)
        {
            using (var fileStream = new FileStream(Path.Combine(_dir, $"{someForm.Name}"), FileMode.Create, FileAccess.Write))
            {
                someForm.File.CopyTo(fileStream);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MultipleFiles(IEnumerable<IFormFile> files)
        {
            foreach (var file in files)
            {
                using (var fileStream = new FileStream(Path.Combine(_dir, $"{file.FileName}"), FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult SingleFile(IFormFile file)
        {
            using (var fileStream = new FileStream(Path.Combine(_dir, $"{file.FileName}"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }

            return RedirectToAction("Index");
        }
    }
}
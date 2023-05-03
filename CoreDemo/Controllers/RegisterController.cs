using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());

        [HttpGet] //sayfa yüklendiği anda çalışır
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] //sayfada buton tetiklenince çalışır
        public IActionResult Index(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult result = wv.Validate(p);

            if (result.IsValid)
            {
                if (p.WriterPassword == p.ConfirmPassword)
                {
                    p.WriterStatus = true;
                    wm.AddWriter(p);
                    return RedirectToAction("Index", "Blog");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View();
        }
    }
}

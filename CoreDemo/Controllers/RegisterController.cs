using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
            if (p.WriterPassword == p.ConfirmPassword)
            {
                p.WriterStatus = true;
                wm.AddWriter(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {

                return View("Index", "Register");
            }
               
         
        }
    }
}

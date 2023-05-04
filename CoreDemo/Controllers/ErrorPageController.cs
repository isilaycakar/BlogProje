using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code) // Program.cs => app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");
        {
            return View();
        }
    }
}

using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var values = bm.GetListWithCategoryByWriterBm(3);
            return View(values);
        }
        public IActionResult BlogAdd()
        {       
            List<SelectListItem> categorivalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.cv = categorivalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog b)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(b);

            if (result.IsValid)
            {

                b.BlogStatus = true;
                b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                b.WriterID = 3;
                bm.TAdd(b);
                return RedirectToAction("BlogListByWriter", "Blog");

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

        public IActionResult BlogDelete(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        public IActionResult BlogEdit(int id) 
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categorivalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.cv = categorivalues;
            return View(blogvalue); 
        }

        [HttpPost]
        public IActionResult BlogEdit(Blog b)
        {
            b.WriterID = 3;
            b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.BlogStatus = true;
            bm.TUpdate(b);
            return RedirectToAction("BlogListByWriter");
        }
    }
}

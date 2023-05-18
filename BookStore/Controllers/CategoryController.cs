using BookStore.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        static Model1 db = new Model1();

        public ActionResult Index(string categoryName = "", int page = 1, int pagesize = 6)
        {
            IPagedList<Book> books;
            if (categoryName.Equals("tat-ca"))
            {
                books = db.Books.OrderByDescending(m => m.UpdateDate).ToPagedList(page, pagesize);
            }
            else
            {
                books = db.Books.Where(m => m.Category.Name.Contains(categoryName)).OrderByDescending(m => m.UpdateDate).ToPagedList(page, pagesize);
            }
            ViewBag.categoryName = categoryName;
            return View(books);
        }
    }
}
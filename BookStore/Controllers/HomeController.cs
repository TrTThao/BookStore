using BookStore.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        static Model1 db = new Model1();
        public ActionResult Index(string Search = "", int page = 1, int pagesize = 6)
        {
            IPagedList<Book> books;
            books = db.Books.Where(m => m.Name.Contains(Search)).OrderByDescending(m => m.UpdateDate).ToPagedList(page, pagesize);
            ViewBag.Search = Search;

            return View(books);
        }

        public ActionResult _Navigation()
        {

            return PartialView(db.Categories.ToList());
        }

        public ActionResult Logout()
        {
            Session.Remove(Commons.USER.USER_SESSION);
            Session.Remove(Commons.USER.ADMIN_SESSION);
            Commons.USER.log = false;
            return RedirectToAction("Index");
        }

        

    }
}
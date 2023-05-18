using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        static Model1 db = new Model1();
        public ActionResult Index(int id)
        {
            DetailModel x = new DetailModel();
            x.book = db.Books.SingleOrDefault(m => m.ID.Equals(id));
            x.similarbooks = db.Books.Where(m => m.Category.ID.Equals(x.book.Category.ID)).ToList();
            return View(x);
        }
    }
}
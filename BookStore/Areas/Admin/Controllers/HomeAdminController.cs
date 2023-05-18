using BookStore.Areas.Admin.Models;
using BookStore.Controllers;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class HomeAdminController : BaseADMINController
    {
        // GET: Admin/HomeAdmin
        static Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book b = db.Books.SingleOrDefault(m => m.ID == id);
            BookTempModel t = new BookTempModel()
            {
                ID = b.ID,
                Name = b.Name,
                AuthorID = b.AuthorID,
                BookTypeID = b.BookTypeID,
                Decription = b.Decription,
                ImagePath = b.ImagePath,
                Note = b.Note,
                NumberOfInventory = b.NumberOfInventory,
                Price = b.Price.ToString(),
                PublisherID = b.PublisherID,
                UpdateDate = b.UpdateDate
            };
            BookModel x = new BookModel()
            {
                authors = db.Authors.ToList(),
                categories = db.Categories.ToList(),
                publishers = db.Publishers.ToList(),
                book = t
            };
            return View(x);
        }

        [HttpPost]
        public JsonResult Edit(BookModel data)
        {
            try
            {
                Book t = db.Books.SingleOrDefault(m => m.ID == data.book.ID);
                t.Name = data.book.Name;
                t.Price = double.Parse(data.book.Price.ToString(), CultureInfo.CreateSpecificCulture("en-US"));
                t.Decription = data.book.Decription;
                t.NumberOfInventory = data.book.NumberOfInventory;
                t.Note = data.book.Note;
                t.ImagePath = data.book.ImagePath;
                t.BookTypeID = data.book.BookTypeID;
                t.AuthorID = data.book.AuthorID;
                t.PublisherID = data.book.PublisherID;
                db.SaveChanges();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });

            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book x = db.Books.SingleOrDefault(m => m.ID == id);
            db.Books.Remove(x);
            db.SaveChanges();
            return RedirectToAction("ListBook");
        }

        [HttpGet]
        public ActionResult ListBook()
        {
            IEnumerable<Book> lst = db.Books.ToList();
            return View(lst);
        }

        [HttpGet]
        [ActionName("CreateNewBook")]
        public ActionResult CreateNewBook()
        {
            return View();
        }
        [HttpPost]
        [ActionName("CreateNewBook")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewBook(BookModel x)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Book b = new Book()
                    {
                        Name = x.book.Name,
                        Price = double.Parse(x.book.Price.ToString(), CultureInfo.CreateSpecificCulture("en-US")),
                        Decription = x.book.Decription,
                        NumberOfInventory = x.book.NumberOfInventory,
                        UpdateDate = DateTime.Now,
                        Note = x.book.Note,
                        ImagePath = x.book.ImagePath,
                        BookTypeID = x.book.BookTypeID,
                        AuthorID = x.book.AuthorID,
                        PublisherID = x.book.PublisherID

                    };
                    db.Books.Add(b);
                    db.SaveChanges();
                    return RedirectToAction("CreateNewBook");
                }
                else
                    return View(x);
            }
            catch
            {
                return View(x);
            }



        }

        public ActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddAuthor(string AuthorName, string job)
        {
            try
            {
                Author a = new Author()
                {
                    Name = AuthorName,
                    Job = job
                };
                db.Authors.Add(a);
                db.SaveChanges();
                return Json(new { status = true });

            }
            catch
            {
                return Json(new { status = false });

            }

        }

        [HttpPost]
        public JsonResult AddCategory(string category)
        {
            try
            {
                Category x = new Category() { Name = category };
                db.Categories.Add(x);
                db.SaveChanges();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
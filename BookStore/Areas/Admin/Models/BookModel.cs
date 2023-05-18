using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Areas.Admin.Models
{
    public class BookModel
    {
        public List<Category> categories { get; set; }
        public List<Author> authors { get; set; }
        public List<Publisher> publishers { get; set; }
        public BookTempModel book { get; set; }
    }
}
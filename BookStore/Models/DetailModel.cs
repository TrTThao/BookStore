using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class DetailModel
    {
        public Book book { get; set; }

        public IEnumerable<Book> similarbooks { get; set; }
    }
}
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Areas.Admin.Commons
{
    public class OrderCommon
    {
        public static Model1 db = new Model1();
        public static int NumberOrder = db.Orders.Count(m => m.Status == true);
    }
}
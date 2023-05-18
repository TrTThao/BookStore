using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Areas.Admin.Models
{
    public class ManageOrderModel
    {
        public Order order { get; set; }
        public List<OrderDetail> orderDetails { get; set; }

        public double intoMoney { get; set; }
    }
}
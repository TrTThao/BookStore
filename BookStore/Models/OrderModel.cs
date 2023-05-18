using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class OrderModel
    {
        public List<CartModel> cartModels { get; set; }
        public int id { get; set; }

        public Order order { get; set; }

        public User user { get; set; }
    }
}
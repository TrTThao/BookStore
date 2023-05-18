using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class CartModel
    {
        public Book book { get; set; }
        public int Quantity { get; set; }
        public double IntoMoney { get; set; }


        
    }
}
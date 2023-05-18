using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BoughtController : BaseController
    {
        // GET: Bought
        static Model1 db = new Model1();

        public ActionResult Index()
        {
            var user = Session[Commons.USER.USER_SESSION] as User;
            var o = db.Orders.Where(m => m.UserID == user.ID).ToList();
            List<OrderModel> lst = new List<OrderModel>();
            foreach(var x in o)
            {
                var listOd = db.OrderDetails.Where(m => m.OrderID == x.ID);
                OrderModel orderModel = new OrderModel();
                orderModel.cartModels = new List<CartModel>();
                foreach (var l in listOd)
                {
                    CartModel cart = new CartModel()
                    {
                        book = db.Books.SingleOrDefault(m => m.ID == l.BookID),
                        Quantity = int.Parse(l.NumberOfBooks.ToString()),
                        IntoMoney= int.Parse(l.NumberOfBooks.ToString()) * int.Parse(l.PriceOfBook.ToString())
                    };
                    
                    orderModel.cartModels.Add(cart);
                }
                orderModel.id = x.ID;
                orderModel.order = x;
                orderModel.user = user;
                lst.Add(orderModel);

            }
            return View(lst);
        }
    }
}
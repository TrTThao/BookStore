using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BookStore.Controllers
{

    public class CartController : BaseController
    {
        // GET: Cart
        static Model1 db = new Model1();

        private const string CartSession = "CartSession";

        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var lst = new List<CartModel>();
            if (cart != null)
            {
                lst = (List<CartModel>)cart;
            }
            ViewBag.MoneyToTal = lst.Sum(m => m.Quantity * m.book.Price);

            return View(lst);
        }

        [HttpGet]
        [NotAuthorize]
        public ActionResult AddBookToCart(int id, int quantity)
        {

            var b = db.Books.SingleOrDefault(m => m.ID == id);

            if (Session[CartSession] == null)
            {
                if(b.NumberOfInventory>quantity)
                {
                    var lst = new List<CartModel>();
                    CartModel model = new CartModel();
                    model.book = b;
                    model.Quantity = quantity;
                    model.IntoMoney = quantity * double.Parse(b.Price.ToString());
                    lst.Add(model);

                    Session[CartSession] = lst;
                }
                
            }
            else
            {
                var lst = Session[CartSession] as List<CartModel>;
                CartModel obj = lst.Where(m => m.book.ID == id).SingleOrDefault();
                if (obj != null)
                {
                    if((obj.Quantity+quantity)>b.NumberOfInventory)
                    {
                        ViewBag.limited = true;
                        return RedirectToAction("Index", "Cart");
                    }
                    else
                    {
                        obj.Quantity += quantity;
                        obj.IntoMoney = obj.Quantity * double.Parse(b.Price.ToString());
                        ViewBag.limited = false;

                    }

                }
                else
                {
                    if (quantity <= b.NumberOfInventory)
                    {
                        obj = new CartModel()
                        {
                            book = b,
                            Quantity = quantity,
                            IntoMoney = quantity * double.Parse(b.Price.ToString())

                        };
                        lst.Add(obj);
                    }
                        
                }
                Session[CartSession] = lst;
            }


            return RedirectToAction("Index");

        }
        public JsonResult UpdateCart(string cartModel)
        {

            var JsonObj = new JavaScriptSerializer().Deserialize<List<CartModel>>(cartModel);
            var SessionCart = (List<CartModel>)Session[CartSession];
            foreach (var item in SessionCart)
            {
                var jsonItem = JsonObj.SingleOrDefault(m => m.book.ID == item.book.ID);
                var b = db.Books.SingleOrDefault(m => m.ID == item.book.ID);
                if (jsonItem != null)
                {
                    if(jsonItem.Quantity<=b.NumberOfInventory)
                    {
                        item.Quantity = jsonItem.Quantity;
                        item.IntoMoney = item.Quantity * double.Parse(item.book.Price.ToString());
                    }
                    
                }
            }
            Session[CartSession] = SessionCart;
            return Json(new { status = true });

        }

        public JsonResult Delete(int id)
        {


            var SessionCart = (List<CartModel>)Session[CartSession];
            SessionCart.Remove(SessionCart.SingleOrDefault(m => m.book.ID == id));
            Session[CartSession] = SessionCart;
            return Json(new { status = true });

        }



        [HttpPost]
        public JsonResult Checkout(string address, string phone, string note)
        {
            var user = Session[Commons.USER.USER_SESSION] as User;
            var listBook = Session[CartSession] as List<CartModel>;
            try
            {
                if (listBook.Count >= 1)
                {
                    try
                    {
                        Order o = new Order()
                        {
                            OrderDate = DateTime.Now,
                            DeliveryDate = DateTime.Now.AddDays(3),
                            Address = address,
                            Phone = phone,
                            Receiver = user.Name,
                            Status = true,
                            Note = note,
                            UserID = user.ID
                        };
                        db.Orders.Add(o);
                        db.SaveChanges();
                        o = db.Orders.Where(m => m.Status == true && m.UserID == user.ID).OrderByDescending(m => m.OrderDate).ToList().FirstOrDefault();

                        foreach (var x in listBook)
                        {
                            OrderDetail od = new OrderDetail()
                            {
                                BookID = x.book.ID,
                                OrderID = o.ID,
                                NumberOfBooks = x.Quantity,
                                PriceOfBook = x.book.Price
                            };
                            db.OrderDetails.Add(od);
                            db.SaveChanges();
                        }
                        return Json(new { status = true });
                    }
                    catch
                    {
                        return Json(new { status = false });

                    }
                }
                else
                {
                    return Json(new { status = false });

                }
            }
            catch
            {
                return Json(new { status = false });
            }
           


        }

        public ActionResult DeleteCart()
        {
            Session.Remove(CartSession);
            return RedirectToAction("Index");
        }



    }
}
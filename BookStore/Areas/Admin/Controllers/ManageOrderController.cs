using BookStore.Areas.Admin.Models;
using BookStore.Controllers;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class ManageOrderController : BaseADMINController
    {
        // GET: Admin/ManageOrder
        static Model1 db = new Model1();

        public ActionResult Index()
        {

            List<Order> lst = db.Orders.OrderBy(m=>m.OrderDate).ToList();
            return View(lst);
        }
        public ActionResult Details(int id)
        {
            ManageOrderModel model = new ManageOrderModel();
            model.order = db.Orders.SingleOrDefault(m => m.ID == id);
            model.orderDetails = db.OrderDetails.Where(m=>m.OrderID==id).ToList();
            model.intoMoney = db.OrderDetails.Where(m => m.OrderID == id).Sum(m => (double)(m.PriceOfBook * m.NumberOfBooks));
            return View(model);
        }

        [HttpPost]
        public JsonResult Confirm(int id)
        {
            var od = db.Orders.SingleOrDefault(m => m.ID == id);
            od.Status = false;
            db.SaveChanges();
            return Json(new { status = true });
        }

        [HttpPost]
        public JsonResult Cancel(int id)
        {
            var od = db.Orders.SingleOrDefault(m => m.ID == id);
            db.Orders.Remove(od);
            db.SaveChanges();
            return Json(new { status = true });
        }
    }
}
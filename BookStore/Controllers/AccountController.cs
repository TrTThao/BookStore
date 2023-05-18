using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        static Model1 db = new Model1();

        public ActionResult Index()
        {
            User x = Session[Commons.USER.USER_SESSION] as User;
            return View(x);
        }
        [HttpPost]
        public ActionResult Index(User x)
        {
            User k = db.Users.SingleOrDefault(m => m.ID == x.ID);
            k.Name = x.Name;
            k.Phone = x.Phone;
            k.Sex = x.Sex;
            k.Email = x.Email;
            db.SaveChanges();
            Session[Commons.USER.USER_SESSION] = k;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ChangePW()
        {
            var u = Session[Commons.USER.USER_SESSION] as User;
            ChangePasswordModel m = new ChangePasswordModel()
            {
                Username = u.Username
            };
            return View(m);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePW(ChangePasswordModel model)
        {
            if(ModelState.IsValid)
            {
                var pass = Helper.MD5.ToMD5(model.OldPassword);
                var u = db.Users.SingleOrDefault(x => x.Username == model.Username&&x.Password==pass);
                if (u==null)
                {
                    ModelState.AddModelError("", "Mật khẩu cũ không đúng");
                    return View(model);
                }
                else
                {
                    if(model.NewPassword!=model.ConfirmPassword)
                    {
                        ModelState.AddModelError("", "Mật khẩu xác nhận không khớp");
                        return View(model);
                    }
                    else
                    {
                        u.Password = Helper.MD5.ToMD5(model.NewPassword);
                        db.SaveChanges();
                        Session[Commons.USER.USER_SESSION] = u;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                return View(model);
            }
            
        }
    }
}
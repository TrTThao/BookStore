using BookStore.Helper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        static Model1 db = new Model1();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel x)
        {
            if (ModelState.IsValid)
            {
                var pass = MD5.ToMD5(x.Password);
                User u = db.Users.SingleOrDefault(m => m.Username.Equals(x.Username) && m.Password.Equals(pass));
                if (u == null)
                {
                    ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không chính xác");
                }
                else
                {
                    if (u.isAdmin == false)
                    {
                        Session.Add(Commons.USER.USER_SESSION, u);
                        return RedirectToAction("Index", "Cart");
                    }
                    else
                    {
                        Session.Add(Commons.USER.ADMIN_SESSION, u);
                        return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
                    }

                }
            }
            return View(x);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Register(RegisterModel da)
        {
            if (ModelState.IsValid)
            {
                if (da.Password != da.ConfirmPassword)
                {
                    return Json(new { status = "-1" });
                }
                else
                {
                    if (db.Users.SingleOrDefault(m => m.Username == da.Username) == null)
                    {
                        User x = new User()
                        {
                            Email = da.Email,
                            Password = Helper.MD5.ToMD5(da.Password),
                            isAdmin = false,
                            Name = da.Name,
                            Phone = da.Phone,
                            RegistrationDate = DateTime.Now,
                            Sex = da.Sex,
                            Username = da.Username
                        };
                        db.Users.Add(x);
                        db.SaveChanges();
                        return Json(new { status = "1" });
                    }
                    else
                    {
                        return Json(new { status = "-2" });

                    }
                }


            }
            else
            {
                return Json(new { status = "0" });

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BaseADMINController: Controller
    {
        public class NotAuthorizeAttribute : FilterAttribute
        {
            // Does nothing, just used for decoration
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object[] attributes = filterContext.ActionDescriptor.GetCustomAttributes(true);
            if (attributes.Any(a => a is NotAuthorizeAttribute)) return;
            if (Session[Commons.USER.ADMIN_SESSION] == null)
            {
                filterContext.Result = new RedirectResult("/Login/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
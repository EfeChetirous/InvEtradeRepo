using Inveon.Admin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inveon.Admin.Core
{
    public class BaseController : Controller
    {
        public ApplicationUser CurrentUser
        {
            get
            {
                if (HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>() != null)
                {
                    return UserManager.FindById(User.Identity.GetUserId());
                }
                return null;
            }
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}
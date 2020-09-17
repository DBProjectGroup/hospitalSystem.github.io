using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hosptialService1;

namespace hospital1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (MyContext ctx = new MyContext())
            {
                //Account us = new Account { user_ID = "3366", name = "tj", password = "456", account_type = "Manager" };
                //ctx.Accounts.Add(us);
               //ctx.SaveChanges();
            }
            return Content("OK");
        }
    }
}
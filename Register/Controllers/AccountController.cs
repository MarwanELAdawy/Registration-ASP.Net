using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Register.Models;

namespace Register.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
			using (Context db = new Context())
			{
				return View(db.userAccount.ToList());
			}
        }

		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(UserAccount account)
		{
			if (ModelState.IsValid)
			{
				using (Context db = new Context())
				{
					db.userAccount.Add(account);
					db.SaveChanges();

				}
				ModelState.Clear();
				ViewBag.Message = account.userName + " Successfuly Registered";
			}
			return View();
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(UserAccount user)
		{
			using (Context db = new Context())
			{
				var usr = db.userAccount.Where(u => u.userName == user.userName && u.Password == user.Password).FirstOrDefault();
				if(usr != null)
				{
					Session["UserID"] = usr.userId.ToString();
					Session["UserName"] = usr.userName.ToString();
					return RedirectToAction("LoggedIn");
				}
				else
				{
					ModelState.AddModelError("","UserName or Password is wrong");
				}

			}
			return View();
		}

		public ActionResult LoggedIn()
		{
			if(Session["UserID"] !=null )
			{
				return View();
			}
			else
			{
				return RedirectToAction("Login");
			}
		}
	}
}
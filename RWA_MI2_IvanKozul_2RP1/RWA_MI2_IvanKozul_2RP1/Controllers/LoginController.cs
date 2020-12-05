using RWA_MI2_IvanKozul_2RP1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_MI2_IvanKozul_2RP1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public string GetLoginRole(string username, string pass)
        {
            Repo repo = new Repo();
            string returnValue = repo.CheckLogin(username, pass).ToString();

            Session["UserRole"] = returnValue;

            return returnValue;
        }

        [HttpGet]
        public string GetRole()
        {
            return Session["UserRole"].ToString();
        }
    }
}
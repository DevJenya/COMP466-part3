using part3.Models;
using part3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace part3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult SubmitOrder()
        {


            return View("Login");
        }

        public ActionResult RecoverPassword()
        {
            return View("RecoverPassword");
        }

        public string ReturnPassword(string username, string email)
        {
            UserModel user = new UserModel();
            user.Username = username;
            user.email = email;

            SecurityService securityService = new SecurityService();

            return securityService.RecoverPassword(user);
        }

        public ActionResult CreateUser()
        {
            return View("CreateUser");
        }

        public ActionResult Login(string username, string password)
        {
            UserModel userModel = new UserModel();
            userModel.Username = username;
            userModel.Password = password;

            SecurityService securityService = new SecurityService();
            int userID = 0;
            userID = securityService.Authenticate(userModel);

                HttpCookie cookie = new HttpCookie("authorized");
                cookie["name"] = username;
                cookie["userID"] = userID.ToString();               

                //("authorized", userModel.Username);
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");                
        }

        [HttpPost]
        public ActionResult Logout()
        {
                HttpCookie cookie = Request.Cookies["authorized"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public string CheckUserName(string username)
        {
            SecurityService securityService = new SecurityService();
            if (securityService.UserExists(username))
            {
                return "exists";
            }

            return "notexists"; 
        }

        public bool CreateUserAccount(string username, string password, string email)
        {
            SecurityService securityService = new SecurityService();
            UserModel user = new UserModel();
            user.Username = username; 
            user.Password = password; 
            user.email = email;

            return securityService.CreateUser(user);
        }

    }
}
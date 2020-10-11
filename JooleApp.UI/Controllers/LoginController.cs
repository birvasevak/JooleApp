using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleApp.Domain;
using JooleApp.Services.ModelService;

using System.Web.Helpers;


namespace JooleApp.UI.Controllers
{
    public class LoginController : Controller
    {

        private UserService service;

        public LoginController()
        {
            this.service = new UserService();
        }

        public LoginController(UserService service)
        {
            this.service = service;
        }

        // GET: Login
      

        public List<tblUser> GetUsers()
        {
            List<tblUser> users = service.GetAll().ToList<tblUser>();

            return users;
        }

        ////[Authorize]
        //[HttpPost]
        //public ActionResult Authorize(string username, string password)
        //{
        //    HttpCookie cookie = new HttpCookie("tblJooleUser");

        //    var userDetails = service.GetUsers(x => x.userID == username &&
        //      x.Password == userModel.Password).FirstOrDefault();
        //    if (userDetails == null)
        //    { //login failed
        //        userModel.LoginErrorMessage = "Wrong Login ID or Password.";
        //        return View("Login", userModel);
        //    }
        //    else
        //    { //login success
        //        System.Web.Security.FormsAuthentication.SetAuthCookie(userModel.userID.ToString(), false);

        //        Session["userID"] = userDetails.userID;
        //        Session["userName"] = userDetails.FirstName;
        //        //if (userModel.RememberMe)
        //        //{

        //        //    //cookie.Values.Add("LoginID", userDetails.LoginID);
        //        //    cookie["loginID"] = userModel.UserID;
        //        //    cookie.Expires = DateTime.Now.AddDays(15);
        //        //    HttpContext.Response.Cookies.Add(cookie);

        //        //}
        //        return RedirectToAction("Index", "Order"); //action name, controller name
        //    }


        //}

        // GET: Login
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["."];
            if (cookie != null)
            {
                var userID = cookie["LoginID"].ToString();
                ViewBag.LoginID = userID;
            }
            return View();
        }

       
    }

}

  

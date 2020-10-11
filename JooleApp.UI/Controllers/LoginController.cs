﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleApp.Domain;
using JooleApp.Services.ModelService;
<<<<<<< Updated upstream

using System.Web.Helpers;


=======
using System.Web.Helpers;

>>>>>>> Stashed changes
namespace JooleApp.UI.Controllers
{
    public class LoginController : Controller
    {
<<<<<<< Updated upstream

        private UserService service;

=======
        private UserService service;
        
>>>>>>> Stashed changes
        public LoginController()
        {
            this.service = new UserService();
        }

        public LoginController(UserService service)
        {
            this.service = service;
        }

        // GET: Login
<<<<<<< Updated upstream
      

        public List<tblUser> GetUsers()
        {
            List<tblUser> users = service.GetAll().ToList<tblUser>();

            return users;
=======
        public ActionResult Index()
        {
            var model = service.GetAll();

            return View(model);
>>>>>>> Stashed changes
        }

        //[Authorize]
        [HttpPost]
<<<<<<< Updated upstream
        public ActionResult Authorize(JooleApp.Domain.tblUser userModel)
        {
            HttpCookie cookie = new HttpCookie("tblJooleUser");

            var userDetails = service.GetUserAuth(userModel.userName, userModel.password).FirstOrDefault();
              
            if (userDetails == null)
            { //login failed
                
                ViewBag.LoginErrorMessage = "Wrong Login ID or Password.";
                return View("Index");
            }
            else
            { //login success
                System.Web.Security.FormsAuthentication.SetAuthCookie(userModel.userName, false);

                Session["userID"] = userDetails.userID;
                Session["userName"] = userDetails.userName;
                //if (userModel.RememberMe)
                //{

                //    //cookie.Values.Add("LoginID", userDetails.LoginID);
                //    cookie["loginID"] = userModel.UserID;
                //    cookie.Expires = DateTime.Now.AddDays(15);
                //    HttpContext.Response.Cookies.Add(cookie);

                //}
                return RedirectToAction("Index", "Category"); //action name, controller name
            }


        }

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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(JooleApp.Domain.tblUser userModel)
        {
            if (ModelState.IsValid)
            {
                var userDetails = service.GetUserByName(userModel.userName).FirstOrDefault();

                
                if (userDetails == null)
                {
                    //userDetails.userName = userModel.userName;
                    //userDetails.password = userModel.password;
                    service.Insert(userModel);
                    ViewBag.LogInMessage = "Success!";
                    return RedirectToAction("Index");
                    
                }
                else
                {
                    ViewBag.LogInMessage = "User name already exists";
                    return View();
                }


            }
            return View();


        }


        public ActionResult LogOut()
        {
            //int loginID = (int) Session["loginID"];
            //Session.Abandon();
            return RedirectToAction("Login", "Login"); //action name, controller name
        }




    }

}

  
=======
        public ActionResult Authorize(tblUser userModel)
        {
            HttpCookie cookie = new HttpCookie("tblJooleUser");

                var userDetails = UserRepo.GetUsers(x => x.userID == userModel.LoginID &&
                  x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                { //login failed
                    userModel.LoginErrorMessage = "Wrong Login ID or Password.";
                    return View("Login", userModel);
                }
                else
                { //login success
                    System.Web.Security.FormsAuthentication.SetAuthCookie(userModel.userID.ToString(), false);

                    Session["userID"] = userDetails.userID;
                    Session["userName"] = userDetails.FirstName;
                    //if (userModel.RememberMe)
                    //{

                    //    //cookie.Values.Add("LoginID", userDetails.LoginID);
                    //    cookie["loginID"] = userModel.UserID;
                    //    cookie.Expires = DateTime.Now.AddDays(15);
                    //    HttpContext.Response.Cookies.Add(cookie);

                    //}
                    return RedirectToAction("Index", "Order"); //action name, controller name
                }
            

        }
    }
}
>>>>>>> Stashed changes

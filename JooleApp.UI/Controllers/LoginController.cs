﻿using System;
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

      

        //[Authorize]
        [HttpPost]

        public ActionResult Authorize(JooleApp.Domain.tblUser userModel)
        {
            HttpCookie cookie = new HttpCookie("tblJooleUser");

            var userDetails = service.GetUserAuth(userModel.userName, userModel.password).FirstOrDefault();
              
            if (userDetails == null)
            { //login failed
                
                ViewBag.LoginErrorMessage = "Wrong Login ID or Password.";
                return View("LoginPage");
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
        public ActionResult LoginPage()
        {
            HttpCookie cookie = Request.Cookies["."];
            if (cookie != null)
            {
                var userID = cookie["LoginID"].ToString();
                ViewBag.LoginID = userID;
            }
            ViewBag.RegisterMessage ="";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(JooleApp.Domain.tblUser userModel, HttpPostedFileBase inputFile)
        {
            if (ModelState.IsValid)
            {
                var userDetails = service.GetUserByName(userModel.userName).FirstOrDefault();

                
                if (userDetails == null)
                {
                    if (inputFile != null)
                    {
                        string ImageName = System.IO.Path.GetFileName(inputFile.FileName);
                        string physicalPath = Server.MapPath("~/images/" + ImageName);

                        // save image in folder
                        inputFile.SaveAs(physicalPath);
                        userModel.userImage = ImageName;
                        ViewBag.ImagePath = ImageName;
                    }

                    service.Insert(userModel);
                    ViewBag.RegisterMessage = "Success!";

                    return View(userModel);

                }
                else
                {
                    ViewBag.RegisterMessage = "User name already exists";
                    
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

  


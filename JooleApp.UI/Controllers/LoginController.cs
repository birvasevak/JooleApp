using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleApp.Domain;
using JooleApp.Services.ModelService;
<<<<<<< Updated upstream
=======
using System.Web.Helpers;
>>>>>>> Stashed changes

namespace JooleApp.UI.Controllers
{
    public class LoginController : Controller
    {
<<<<<<< Updated upstream
        // GET: Login
        public ActionResult Login()
        {
            HttpCookie cookie = Request.Cookies["."];
            if (cookie != null)
            {
                var userID = cookie["LoginID"].ToString();
                ViewBag.LoginID = userID;
            }
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
=======
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
        public ActionResult Index()
        {
            var model = service.GetAll();

            return View(model);
        }

        //[Authorize]
        [HttpPost]
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

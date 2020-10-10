using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleApp.Domain;
using JooleApp.Services.ModelService;

namespace JooleApp.UI.Controllers
{
    public class CategoryController : Controller
    {
        private ProductCategoryService service;

        public CategoryController()
        {
            this.service = new ProductCategoryService();
        }

        public CategoryController(ProductCategoryService service)
        {
            this.service = service;
        }



        // GET: Category
        public ActionResult Index()
        {
            var model = service.GetAll();
            
            return View(model);
        }

        /*public ActionResult GetSubCategories()
        {
            int id = 1;
            List<tblSubCategory> model = service.GetTblSubCategories(id).ToList<tblSubCategory>();
            return View("Index", model);
        }*/
    }
}
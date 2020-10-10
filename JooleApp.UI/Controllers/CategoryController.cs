using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleApp.Repository.Repositories;
using JooleApp.Domain;

namespace JooleApp.UI.Controllers
{
    public class CategoryController : Controller
    {
        //private Repository<tblCategory> repository = null;
        private ProductCategoryRepo repository = null;

        public CategoryController()
        {
            //this.repository = new Repository<tblCategory>();
            this.repository = new ProductCategoryRepo();
        }

        public CategoryController(ProductCategoryRepo repository)
        {
            this.repository = repository;
        }



        // GET: Category
        public ActionResult Index()
        {
            var model = repository.GetAll();
            
            return View(model);
        }

        public IEnumerable<tblSubCategory> GetSubCategories(int CatID)
        {
            var model = repository.GetSubCategories(CatID);
            ViewBag.subCats = model;
            return model;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleApp.Domain;
using JooleApp.Services.ModelService;

namespace JooleApp.UI.Controllers
{
    public class SearchController : Controller
    {
        private ProductCategoryService service;

        public SearchController()
        {
            this.service = new ProductCategoryService();
        }

        public SearchController(ProductCategoryService service)
        {
            this.service = service;
        }



        // GET: Category
        public ActionResult SearchPage()
        {
            ViewBag.CategoryList = new SelectList(GetCategories(), "categoryID", "categoryName");
            return View();
        }

        public List<tblCategory> GetCategories()
        {
            List<tblCategory> categories = service.GetAll().ToList<tblCategory>();

            return categories;
        }

        public ActionResult GetSubCategoryList(int categoryId)
        {
            List<tblSubCategory> selectList = service.GetbyCategoryID(categoryId).ToList<tblSubCategory>();
            //IEnumerable<JooleAppEntities> selectLi = service.GetAll().Where(m => m.categoryID == categoryId).;
            ViewBag.SubCategoryList = new SelectList(selectList, "subCategoryID", "categoryName");

            return PartialView("DisplaySubCategories");
            //return Json(selectList, JsonRequestBehavior.AllowGet);
        }

    }
}
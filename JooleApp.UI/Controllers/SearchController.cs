using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleApp.Domain;
using JooleApp.Services.ModelService;
using JooleApp.UI.Models;

namespace JooleApp.UI.Controllers
{
    public class SearchController : Controller
    {
        private ProductCategoryService service;
        private ProductDetailService detailService;

        public SearchController()
        {
            this.service = new ProductCategoryService();
            this.detailService = new ProductDetailService();
        }

        public SearchController(ProductCategoryService service, ProductDetailService detailService)
        {
            this.service = service;
            this.detailService = detailService;
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
            ViewBag.SubCategoryList = new SelectList(selectList, "subCategoryID", "categoryName");
            return PartialView("DisplaySubCategories");
        }

        public ActionResult checkProj(int productID)
        {
            //int productID = 1;
            ViewData["description"] = detailService.getProductDescription(productID);
            ViewData["productType"] = detailService.getProductType(productID);
            ViewData["techSpec"] = detailService.getTechnicalSpec(productID);
            ViewData["withRange"] = detailService.getTechSpecWithRange(productID);
            return View();
        }

        [HttpPost]
        public ActionResult SearchPage(SearchCascadingClass scc)
        {
            return this.RedirectToAction("ProductSummary", "ProductSummary", scc);
        }

        public ActionResult compare(int id1, int id2)
        {
            ViewData["id1"] = id1;
            ViewData["id2"] = id2;
            ViewData["description1"] = detailService.getProductDescription(id1);
            ViewData["productType1"] = detailService.getProductType(id1);
            ViewData["techSpec1"] = detailService.getTechnicalSpec(id1);

            ViewData["description2"] = detailService.getProductDescription(id2);
            ViewData["productType2"] = detailService.getProductType(id2);
            ViewData["techSpec2"] = detailService.getTechnicalSpec(id2);

            return View();
        }
    }
}
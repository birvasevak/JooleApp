﻿using System;
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
            //IEnumerable<JooleAppEntities> selectLi = service.GetAll().Where(m => m.categoryID == categoryId).;
            ViewBag.SubCategoryList = new SelectList(selectList, "subCategoryID", "categoryName");

            return PartialView("DisplaySubCategories");
            //return Json(selectList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SearchPage(SearchCascadingClass scc)
        {
            return this.RedirectToAction("ProductSummary", "ProductSummary", scc);
        }

        public ActionResult checkProj()
        {
            int productID = 0;
            ViewData["ProductsDetails"] = detailService.GetProductDetails(productID);
            ViewData["description"] = detailService.getProductDescription(productID);
            ViewData["type"] = detailService.des(productID);
            return View();
        }

    
 
    }
}
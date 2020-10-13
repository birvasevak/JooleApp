﻿using JooleApp.Domain;
using JooleApp.Services.ModelService;
using JooleApp.UI.DataModels;
using JooleApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace JooleApp.UI.Controllers
{
    public class ProductSummaryController : Controller
    {
        ProductSummaryService serv = new ProductSummaryService();
        SearchCascadingClass sccObj = new SearchCascadingClass();
        // GET: ProductSummary

        public ActionResult ProductSummary(SearchCascadingClass scc)
        {
            ProductDetail pd = new ProductDetail();
            SearchController sc = new SearchController();
            sccObj = scc;
            ViewBag.CategoryList = new SelectList(sc.GetCategories(), "categoryID", "categoryName");
            pd.prodDet = serv.getProdData(scc.SubCategoryID);
            pd.searchPanel = serv.getSubCatAttData(scc.SubCategoryID);

            ViewData["Products"] = pd;
            
            return View();
        }
        
        public PartialViewResult RenderSearchPanel(ProductDetail data)
        {
            return PartialView(data);
        }


        public PartialViewResult RenderProducts(ProductDetail data)
        {
            return PartialView(data);
        }

        [HttpPost]
        public PartialViewResult updateProductsQuery(jsonQueryData queryData)
        {
            foreach(KeyValuePair<String,String> p in queryData.data)
            {
                System.Diagnostics.Debug.WriteLine("Data is " + p.Key + " " + p.Value );
            }
            ProductDetail pd = new ProductDetail();
            System.Diagnostics.Debug.WriteLine("SubCategory ID:" + sccObj.SubCategoryID);
            pd.prodDet = serv.getProdData(queryData.data, int.Parse(queryData.data2["id"]));
            return PartialView("RenderProducts", pd);
        }

        public class jsonQueryData
        {
            public Dictionary<String, String> data { get; set; }
            public Dictionary<String, String> data2 { get; set; }
        }

        public PartialViewResult SearchBar()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult searchBar(SearchCascadingClass scc)
        {
            sccObj = scc;
            System.Diagnostics.Debug.WriteLine("Posted SubCategory ID:" + sccObj.SubCategoryID+" CategoryID"+sccObj.CategoryId);
            return this.RedirectToAction("ProductSummary", "ProductSummary", scc);
        }
    }
}
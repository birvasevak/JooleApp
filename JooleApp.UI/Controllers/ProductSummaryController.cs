using JooleApp.Domain;
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

            //set default avatar
            if (System.Web.HttpContext.Current.Session["UserAvatar"] == null)
            {
                Session["UserAvatar"] = "http://via.placeholder.com/150x150";
            }
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
            pd.prodDet = serv.getProdData(queryData.data, sccObj.SubCategoryID);
            return PartialView("RenderProducts", pd);
        }

        public class jsonQueryData
        {
            public Dictionary<String, String> data { get; set; }
        }

        public PartialViewResult SearchBar()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult searchBar(SearchCascadingClass scc)
        {
            sccObj = scc;
            return this.RedirectToAction("ProductSummary", "ProductSummary", scc);
        }
    }
}
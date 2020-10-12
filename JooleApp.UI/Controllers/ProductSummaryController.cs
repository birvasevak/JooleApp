using JooleApp.Services.ModelService;
using JooleApp.UI.DataModels;
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
        // GET: ProductSummary
        public ActionResult ProductSummary()
        {
            ProductSummaryService serv = new ProductSummaryService();
           
            ViewData["SearchData"] = serv.getSubCatAttData(1);
            ViewData["Products"] = serv.getProdData(1);
            
            return View();
        }


        public PartialViewResult RenderSearchPanel(Dictionary<String, List<String>> data)
        {
            ViewData["dataSearch"] = data;
            return PartialView();
        }


        public PartialViewResult RenderProducts(List<Dictionary<String, String>> data)
        {
            ProductDetail pd = new ProductDetail();
            pd.prodDet = data;
            return PartialView(pd);
        }
    }
}
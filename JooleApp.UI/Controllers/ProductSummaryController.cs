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
            ProductDetail pd = new ProductDetail();
           
            pd.prodDet = serv.getProdData(2);
            pd.searchPanel = serv.getSubCatAttData(2);

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
            pd.prodDet = serv.getProdData(queryData.data, 2);
            return PartialView("RenderProducts", pd);
        }

        public class jsonQueryData
        {
            public Dictionary<String, String> data { get; set; }
        }



    }
}
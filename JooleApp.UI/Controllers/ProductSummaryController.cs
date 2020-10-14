using JooleApp.Domain;
using JooleApp.Services.ModelService;
using JooleApp.UI.DataModels;
using JooleApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            foreach(KeyValuePair<int, List<Dictionary<String, String>>> prod in pd.prodDet)
            {
                string imgPath = Server.MapPath("~" + "/App_Data/" + prod.Value[0]["ProductName"].Replace(" ", "") + ".jpg");

                byte[] byteData = System.IO.File.ReadAllBytes(imgPath);
                string imreBase64Data = Convert.ToBase64String(byteData);
                string imgDataURL = string.Format("data:image/jpg;base64,{0}", imreBase64Data);
                prod.Value[0]["ImagePath"] = imgDataURL;
            }
            TempData["ids"] = new List<String>();
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

        [HttpPost]
        public ActionResult RenderSearchPanel()
        {
            JsonCompareModel jCD = new JsonCompareModel();
            List<String> temp = TempData["ids"] as List<String>;
            jCD.id1 = temp[0];
            jCD.id2 = temp[1];
            System.Diagnostics.Debug.WriteLine(jCD.id1 + " " + jCD.id2);
            return RedirectToAction("compare","Search", jCD);
        }

        public PartialViewResult RenderProducts(ProductDetail data)
        {
            return PartialView(data);
        }

        [HttpPost]
        public PartialViewResult updateProductsQuery(jsonQueryData queryData)
        {
            ProductDetail pd = new ProductDetail();
            System.Diagnostics.Debug.WriteLine("SubCategory ID:" + sccObj.SubCategoryID);
            pd.prodDet = serv.getProdData(queryData.data, int.Parse(queryData.data2["id"]));

            foreach (KeyValuePair<int, List<Dictionary<String, String>>> prod in pd.prodDet)
            {
                string imgPath = Server.MapPath("~" + "/App_Data/" + prod.Value[0]["ProductName"].Replace(" ", "") + ".jpg");
                byte[] byteData = System.IO.File.ReadAllBytes(imgPath);
                string imreBase64Data = Convert.ToBase64String(byteData);
                string imgDataURL = string.Format("data:image/jpg;base64,{0}", imreBase64Data);
                prod.Value[0]["ImagePath"] = imgDataURL;
            }

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

        [HttpPost]
        public ActionResult Clicked(String id)
        {
            List<String> temp = TempData["ids"] as List<String>;
            if (temp.Contains(id))
            {
                temp.Remove(id);
            }
            else
            {
                temp.Add(id);
            }
            TempData["ids"] = temp;
            System.Diagnostics.Debug.WriteLine(temp);
            return new EmptyResult();
        }
    }
}
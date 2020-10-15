using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Windows.Controls;
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

            foreach (var p in detailService.GetAll())
            {
                
                string imgPath = Server.MapPath("~" + "/App_Data/" + p.productName.Replace(" ", "") + ".jpg");

                byte[] byteData = System.IO.File.ReadAllBytes(imgPath);
                string imreBase64Data = Convert.ToBase64String(byteData);
                string imgDataURL = string.Format("data:image/jpg;base64,{0}", imreBase64Data);
                p.imagePath = imgDataURL;
            }

            List<List<tblProduct>> descriptionList = new List<List<tblProduct>>();
            descriptionList.Add(detailService.getProductDescription(id1));
            descriptionList.Add(detailService.getProductDescription(id2));
            descriptionList.Add(detailService.getProductDescription(id2));

            ViewData["descriptionList"] = descriptionList;

            List<Dictionary<string, string>> typeList = new List<Dictionary<string, string>>();
            typeList.Add(detailService.getProductType(id1));
            typeList.Add(detailService.getProductType(id2));
            typeList.Add(detailService.getProductType(id2));

            ViewData["typeList"] = typeList;

            ViewData["kvp"] = detailService.getAllTechnicalSpec(id1);

            List<Dictionary<string, string>> techList = new List<Dictionary<string, string>>();
            techList.Add(detailService.getAllTechnicalSpec(id1));
            techList.Add(detailService.getAllTechnicalSpec(id2));
            techList.Add(detailService.getAllTechnicalSpec(id2));
            ViewData["techList"] = techList;

            return View();
        }
    }
}
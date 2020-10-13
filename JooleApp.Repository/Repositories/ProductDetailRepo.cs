using JooleApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleApp.Repository.Repositories
{
    public class ProductDetailRepo
    {
        JooleAppEntities dbb = null;

        public ProductDetailRepo()
        {
            dbb = StaticUnitOfWork.getContext();
        }

        public ProductDetailRepo(JooleAppEntities context)
        {
            dbb = context;
        }

        public Dictionary<int, List<Dictionary<String, String>>> getProductDetails(int productID)
        {
            using (var db = new JooleAppEntities())
            {
                var productDetails = db.tblProducts.Join(
                                        db.tblProductAttributes,
                                        prod => prod.productID,
                                        patt => patt.productID,
                                        (prod, patt) => new { prod, patt }
                                     ).Where(
                                        p => p.prod.productID == productID
                                     ).Join(
                                        db.tblAttributes,
                                        pattC => pattC.patt.attributeID,
                                        att => att.attributeID,
                                        (pattC, att) => new { att.attributeName, att.isTechSpec, pattC }
                                     ).ToList();

                /*Dictionary<int, Dictionary<String, String>> prodAtts = new Dictionary<int, Dictionary<string, string>>();*/

                Dictionary<int, List<Dictionary<String, String>>> prodAtts = new Dictionary<int, List<Dictionary<string, string>>>();

                foreach (var prod in productDetails)
                {
                    if (prodAtts.ContainsKey(prod.pattC.prod.productID))
                    {
                        prodAtts[prod.pattC.prod.productID][1].Add(prod.attributeName, prod.pattC.patt.attributeValue);
                    }
                    else
                    {
                        prodAtts[prod.pattC.prod.productID] = new List<Dictionary<string, string>>();
                        prodAtts[prod.pattC.prod.productID].Add(new Dictionary<string, string>());
                        prodAtts[prod.pattC.prod.productID].Add(new Dictionary<string, string>());
                        prodAtts[prod.pattC.prod.productID][0].Add("ImagePath", prod.pattC.prod.imagePath);
                        prodAtts[prod.pattC.prod.productID][0].Add("ModelName", prod.pattC.prod.modelName);
                        prodAtts[prod.pattC.prod.productID][0].Add("ModelYear", prod.pattC.prod.modelYear);
                        prodAtts[prod.pattC.prod.productID][0].Add("ProductName", prod.pattC.prod.productName);
                    }
                }

                return prodAtts;
            }
        }

        public List<tblProduct> getProductDescription(int productID)
        {
            List<tblProduct> prodDet = null;
            using (var db = new JooleAppEntities())
            {
                var productDescription = db.tblProducts.Where(p => p.productID == productID);
                prodDet = (from pd in dbb.tblProducts
                           where pd.productID == productID
                           select pd).ToList<tblProduct>();
            }
            return prodDet;
        }

        public Dictionary<string, string> des(int productID)
        {
            using (var db = new JooleAppEntities())
            {
                var des = (from p in dbb.tblProducts
                           join pa in dbb.tblProductAttributes
                           on p.productID equals pa.productID
                           join a in dbb.tblAttributes
                           on pa.attributeID equals a.attributeID
                           where p.productID == productID && (a.attributeName == "Mount" || a.attributeName == "Application")
                           select new { p, pa, a }
                           );

                Dictionary<string, string> newD = new Dictionary<string, string>();

                foreach (var d in des)
                {
                    newD.Add(d.a.attributeName, d.pa.attributeValue);
                }
                return newD;
            }
        }
    }
}

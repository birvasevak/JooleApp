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

        public Dictionary<string, string> getProductType(int productID)
        {
            using (var db = new JooleAppEntities())
            {
                var des = (from p in dbb.tblProducts
                           join pa in dbb.tblProductAttributes
                           on p.productID equals pa.productID
                           join a in dbb.tblAttributes
                           on pa.attributeID equals a.attributeID
                           where (p.productID == productID && a.isTechSpec == false)
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

        public Dictionary<string, string> getTechnicalSpec(int productID)
        {
            using (var db = new JooleAppEntities())
            {
                var des = (from p in dbb.tblProducts
                           join pa in dbb.tblProductAttributes
                           on p.productID equals pa.productID
                           join a in dbb.tblAttributes
                           on pa.attributeID equals a.attributeID
                           join t in dbb.tblTechSpecFilters
                           on pa.attributeID equals t.attributeID
                           where (p.productID == productID && a.isTechSpec == true && t.minVal == t.maxVal)
                           select new { p.productID, a.attributeName, pa.attributeValue } 
                           ).Distinct();

                Dictionary<string, string> newD = new Dictionary<string, string>();

                foreach (var d in des)
                {
                    newD.Add(d.attributeName, d.attributeValue);
                }
                return newD;
            }
        }

        public Dictionary<string, List<string>> getTechSpecWithRange(int productID)
        {
            using (var db = new JooleAppEntities())
            {
                var des = (from p in dbb.tblProducts
                           join pa in dbb.tblProductAttributes
                           on p.productID equals pa.productID
                           join a in dbb.tblAttributes
                           on pa.attributeID equals a.attributeID
                           join t in dbb.tblTechSpecFilters
                           on pa.attributeID equals t.attributeID
                           where (p.productID == productID && a.isTechSpec == true && t.minVal != t.maxVal)
                           select new { p.productID, a.attributeName, t.minVal, t.maxVal }
                           ).Distinct();

                Dictionary<string, List<string>> newD = new Dictionary<string, List<string>>();
                


                foreach (var d in des)
                {
                    List<string> rangeList = new List<string>();
                    rangeList.Add(d.minVal);
                    rangeList.Add(d.maxVal);
                    if (!newD.ContainsKey(d.attributeName))
                    {
                        newD.Add(d.attributeName, rangeList);
                    }
                }
                return newD;
            }
        }
    }
}

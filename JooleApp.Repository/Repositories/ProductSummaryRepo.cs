using JooleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleApp.Repository.Repositories
{
    public class ProductSummaryRepo : IProductSummaryRepo
    {

        JooleApp.Domain.JooleAppEntities dbb = null;

        public ProductSummaryRepo()
        {
            dbb = StaticUnitOfWork.getContext();
        }

        public Dictionary<String, List<String>> getAttributeDetails(int subCategoryID)
        {
            using (var db = new JooleAppEntities())
            {
                var filterAttributes = db.tblAttributes.Join(
                                                db.tblTechSpecFilters,
                                                att => att.attributeID,
                                                tspc => tspc.attributeID,
                                                (att, tspc) => new{
                                                    att.attributeID,
                                                    tspc.subCategoryID,
                                                    att.attributeName,
                                                    tspc.maxVal,
                                                    tspc.minVal,
                                                }).Where(
                                                    ele => ele.subCategoryID == subCategoryID
                                                ).ToList();

                Dictionary<String, List<String>> attVal = new Dictionary<String, List<String>>();

                foreach(var att in filterAttributes)
                {
                    attVal.Add(att.attributeName, new List<String>() { att.minVal, att.maxVal });
                }

                return attVal;
            }
        }

        public Dictionary<int, List<Dictionary<String, String>>> getProductDetails(int subCategoryID)
        {
            using(var db = new JooleAppEntities())
            {
                var productDetails = db.tblProducts.Join(
                                        db.tblProductAttributes,
                                        prod => prod.productID,
                                        patt => patt.productID,
                                        (prod, patt) => new { prod, patt }
                                     ).Join(
                                        db.tblAttributes,
                                        pattC => pattC.patt.attributeID,
                                        att  => att.attributeID,
                                        (pattC, att) => new { att.attributeName, att.isTechSpec, pattC }
                                     ).Where(
                                        p => p.pattC.prod.subCategoryID == subCategoryID
                                     );

                /*Dictionary<int, Dictionary<String, String>> prodAtts = new Dictionary<int, Dictionary<string, string>>();*/

                Dictionary<int, List<Dictionary<String, String>>> prodAtts = new Dictionary<int, List<Dictionary<string, string>>>();

                /*System.Diagnostics.Debug.WriteLine(productDetails.ToString());*/


                foreach (var prod in productDetails.ToList())
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
                        prodAtts[prod.pattC.prod.productID][1].Add(prod.attributeName, prod.pattC.patt.attributeValue);
                        prodAtts[prod.pattC.prod.productID][0].Add("ImagePath",prod.pattC.prod.imagePath);
                        prodAtts[prod.pattC.prod.productID][0].Add("ModelName", prod.pattC.prod.modelName);
                        prodAtts[prod.pattC.prod.productID][0].Add("ModelYear", prod.pattC.prod.modelYear);
                        prodAtts[prod.pattC.prod.productID][0].Add("ProductName", prod.pattC.prod.productName);
                    }
                }

                return prodAtts;
            }
        }

        public Dictionary<int, List<Dictionary<String, String>>> getProductDetailsFromQuery(Dictionary<String,String> queryAtt, int subCategoryID)
        {
            Dictionary<int, List<Dictionary<String, String>>> prodDetails = getProductDetails(subCategoryID);
            Dictionary<int, List<Dictionary<String, String>>> prodDetailsReturn = new Dictionary<int, List<Dictionary<string, string>>>();


            foreach (KeyValuePair<int, List<Dictionary<String, String>>> prod in prodDetails)
            {

                bool addThat = false;

                foreach (KeyValuePair<String, String> att in queryAtt)
                {
                    System.Diagnostics.Debug.WriteLine("" + att.Key + " " + att.Value);
                    if ( Convert.ToDouble(prod.Value[1][att.Key]) <= Convert.ToDouble(att.Value))
                    {
                        addThat = true;
                    }
                    else
                    {
                        addThat = false;
                        break;
                    }
                }
                if (addThat)
                {
                    System.Diagnostics.Debug.WriteLine("Added " + prod.Key);
                    prodDetailsReturn.Add(prod.Key, prod.Value);
                }
            }

            return prodDetailsReturn;
        }
    }
}

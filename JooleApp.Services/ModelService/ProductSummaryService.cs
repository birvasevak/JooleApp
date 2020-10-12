using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleApp.Repository.Repositories;
using JooleApp.Domain;

namespace JooleApp.Services.ModelService
{
    public class ProductSummaryService
    {
        ProductSummaryRepo repo;

        public ProductSummaryService()
        {
            repo = new ProductSummaryRepo();
        }

        public Dictionary<int, List<Dictionary<String, String>>> getProdData(int subCategoryID)
        {
            return repo.getProductDetails(subCategoryID);
        }

        public Dictionary<String, List<String>> getSubCatAttData(int subCategoryID)
        {
            return repo.getAttributeDetails(subCategoryID);
        }
    }
}

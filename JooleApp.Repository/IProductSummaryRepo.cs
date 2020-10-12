using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleApp.Repository
{
    interface IProductSummaryRepo
    {
        Dictionary<int, List<Dictionary<String, String>>> getProductDetails(int subCategoryID);

        Dictionary<String, List<String>> getAttributeDetails(int subCategoryID);
    }
}

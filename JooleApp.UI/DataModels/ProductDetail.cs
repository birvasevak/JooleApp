using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleApp.UI.DataModels
{
    public class ProductDetail
    {
        public Dictionary<String, List<String>> searchPanel { get; set; }

        public Dictionary<int, List<Dictionary<String, String>>> prodDet { get; set; }
    }
}
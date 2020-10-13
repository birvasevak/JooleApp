using JooleApp.Domain;
using JooleApp.Repository;
using JooleApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleApp.Services.ModelService
{
    public class ProductDetailService
    {
        private UnitOfWork unitOfWork;
        private ProductDetailRepo productDetailRepo;

        public ProductDetailService()
        {
            this.unitOfWork = new UnitOfWork();
            this.productDetailRepo = new UnitOfWork().ProductDetailRepo;
        }

        public ProductDetailService(UnitOfWork unitOfWork, ProductDetailRepo productDetailRepo)
        {
            this.unitOfWork = unitOfWork;
            this.productDetailRepo = productDetailRepo;
        }

        public Dictionary<int, List<Dictionary<String, String>>> GetProductDetails(int productID)
        {
            return productDetailRepo.getProductDetails(productID);
        }

        public List<tblProduct> getProductDescription(int productID)
        {
            return productDetailRepo.getProductDescription(productID);
        }

        public Dictionary<string, string> des(int productID)
        {
            return productDetailRepo.des(productID);
        }
    }
}

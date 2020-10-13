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

        public List<tblProduct> getProductDescription(int productID)
        {
            return productDetailRepo.getProductDescription(productID);
        }

        public Dictionary<string, string> getProductType(int productID)
        {
            return productDetailRepo.getProductType(productID);
        }

        public Dictionary<string, string> getTechnicalSpec(int productID)
        {
            return productDetailRepo.getTechnicalSpec(productID);
        }

        public Dictionary<string, List<string>> getTechSpecWithRange(int productID)
        {
            return productDetailRepo.getTechSpecWithRange(productID);
        }
    }
}

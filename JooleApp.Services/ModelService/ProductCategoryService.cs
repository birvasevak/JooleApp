using JooleApp.Repository.Repositories;
using JooleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleApp.Services.ModelService
{
    public class ProductCategoryService
    {
        private ProductCategoryRepo catRepo;
        private Repository<tblSubCategory> subCatRepo;

        public ProductCategoryService(ProductCategoryRepo catRepo, Repository<tblSubCategory> subCatRepo)
        {
            this.catRepo = catRepo;
            this.subCatRepo = subCatRepo;
        }
    }
}

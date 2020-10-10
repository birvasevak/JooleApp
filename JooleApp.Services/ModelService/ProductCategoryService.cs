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

        public ProductCategoryService()
        {
            this.catRepo = new ProductCategoryRepo();
            this.subCatRepo = new Repository<tblSubCategory>();
        }

        public IEnumerable<tblCategory> GetAll()
        {
            return this.catRepo.GetAll();
        }

        public tblCategory GetbyId(int Id)
        {
            return this.catRepo.GetbyId(Id);
        }

        public void Save(tblCategory model)
        {
            this.catRepo.Save();
        }

        public void Delete(tblCategory category)
        {
            this.catRepo.Delete(category);
        }

        public IEnumerable<tblSubCategory> GetTblSubCategories(int catID)
        {
            return this.subCatRepo.GetAll().Where(model => model.categoryID == catID);
        }
    }
}

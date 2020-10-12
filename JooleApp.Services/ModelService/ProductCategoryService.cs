using JooleApp.Repository.Repositories;
using JooleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleApp.Repository;

namespace JooleApp.Services.ModelService
{
    public class ProductCategoryService
    {
        private UnitOfWork unitOfWork;
        //var x = _unitOfWork.ProductCategoryRepo;
        private ProductCategoryRepo catRepo;
        private ProductSubCategoryRepo subCatRepo;

        
        public ProductCategoryService(UnitOfWork unitOfWork, ProductCategoryRepo catRepo, ProductSubCategoryRepo subCatRepo)
        {
            this.unitOfWork = unitOfWork;
            this.catRepo = unitOfWork.ProductCategoryRepo;
            this.subCatRepo = unitOfWork.ProductSubCategoryRepo;
        }

        public ProductCategoryService()
        {
            this.unitOfWork = new UnitOfWork();
            this.catRepo = new UnitOfWork().ProductCategoryRepo;
            this.subCatRepo = new UnitOfWork().ProductSubCategoryRepo;
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

        public List<tblSubCategory> GetTblSubCategories(int catID)
        {
            return this.subCatRepo.GetAll().Where(model => model.categoryID == catID).ToList<tblSubCategory>();
        }

        public IEnumerable<tblSubCategory> GetbyCategoryID(int categoryID)
        {
            return this.subCatRepo.GetAll().Where(m => m.categoryID == categoryID);
        }
    }
}

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
        private Repository<tblSubCategory> subCatRepo;

        
        public ProductCategoryService(UnitOfWork unitOfWork, ProductCategoryRepo catRepo, Repository<tblSubCategory> subCatRepo)
        {
            this.unitOfWork = unitOfWork;
            this.catRepo = unitOfWork.ProductCategoryRepo;
            this.subCatRepo = subCatRepo;
        }

        public ProductCategoryService()
        {
            this.unitOfWork = new UnitOfWork();
            this.catRepo = new UnitOfWork().ProductCategoryRepo;
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

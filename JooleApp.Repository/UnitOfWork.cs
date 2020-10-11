using JooleApp.Domain;
using JooleApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleApp.Repository
{
    public class UnitOfWork : IDisposable
    {

        private JooleAppEntities Context = new JooleAppEntities();
        private ProductCategoryRepo productCategoryRepo;
        private ProductSubCategoryRepo productSubCategoryRepo;

        public UnitOfWork()
        {
            this.Context = new JooleAppEntities();
            productSubCategoryRepo = new ProductSubCategoryRepo(Context);

        }

        public ProductCategoryRepo ProductCategoryRepo
        {
            get
            {
                if(this.productCategoryRepo == null)
                {
                    this.productCategoryRepo = new ProductCategoryRepo(Context);
                }
                return productCategoryRepo;
            }
        }

        public ProductSubCategoryRepo ProductSubCategoryRepo
        {
            get
            {
                if(this.productSubCategoryRepo == null)
                {
                    this.productSubCategoryRepo = new ProductSubCategoryRepo(Context);
                }
                return productSubCategoryRepo;
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();

        }
    }
}

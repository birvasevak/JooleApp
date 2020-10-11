using JooleApp.Domain;
using JooleApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleApp.Repository
{
    public class UnitOfWork : IDisposable
    {

        private JooleAppEntities context = new JooleAppEntities();
        private ProductCategoryRepo productCategoryRepo;
        private UserRepo userRepo;

        public UnitOfWork()
        {
            context = new JooleAppEntities();
        }

        public ProductCategoryRepo ProductCategoryRepo
        {
            get
            {
                if(this.productCategoryRepo == null)
                {
                    this.productCategoryRepo = new ProductCategoryRepo(context);
                }
                return productCategoryRepo;
            }
        }
        public UserRepo UserRepo
        {
            get
            {
                if (this.userRepo == null)
                {
                    this.userRepo = new UserRepo(context);
                }
                return userRepo;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();

        }
    }
}

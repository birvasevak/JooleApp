using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using JooleApp.Domain;

namespace JooleApp.Repository.Repositories
{
    public class ProductCategoryRepo : Repository<tblCategory>
    {
        private JooleAppEntities _context = null;
        private DbSet<tblCategory> entities = null;
        string errorMessage = string.Empty;

        public ProductCategoryRepo()
        {
            this._context = new JooleAppEntities();
            entities = _context.Set<tblCategory>();
        }
        public ProductCategoryRepo(JooleAppEntities context)
        {
            _context = context;
            entities = _context.Set<tblCategory>();
        }

        /*public IEnumerable<tblCategory> GetAll()
        {
            return entities.AsEnumerable();
        }

        public tblCategory GetById(int Id)
        {
            return GetAll().Where(model => model.categoryID == Id).SingleOrDefault();
        }

        public void Insert(tblCategory entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(tblCategory entity)
        {
            //entities.AddOrUpdate(entity);

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public void Delete(tblCategory entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Remove(tblCategory entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
        */
        

        public IEnumerable<tblSubCategory> GetSubCategories(int CatID)
        {
            List<tblSubCategory> subCategories = new List<tblSubCategory>();
            using (var context =  new JooleAppEntities())
            {
                 subCategories = new List<tblSubCategory>().Where(u => u.categoryID == CatID).ToList<tblSubCategory>();
            }
            return subCategories;
        }

    }
}

using JooleApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleApp.Repository.Repositories
{
   public class ProductSubCategoryRepo : Repository<tblSubCategory>
    {
        private JooleAppEntities _context = null;
        private DbSet<tblSubCategory> entities = null;
        string errorMessage = string.Empty;

        public ProductSubCategoryRepo()
        {
            this._context = new JooleAppEntities();
            entities = _context.Set<tblSubCategory>();
        }
        public ProductSubCategoryRepo(JooleAppEntities context)
        {
            _context = context;
            entities = _context.Set<tblSubCategory>();
        }

        public IEnumerable<tblSubCategory> GetAll()
        {
            return entities.AsEnumerable();
        }

        public IEnumerable<tblSubCategory> GetbyCategoryID(int categoryID)
        {
            return GetAll().Where(m => m.categoryID == categoryID);
        }
    }
}

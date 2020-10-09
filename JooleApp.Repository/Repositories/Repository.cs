using JooleApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleApp.Repository.Repositories
{
    public class Repository<T>  where T : class
    {
        private  JooleAppEntities _context = null;
        private DbSet<T> entities = null;
        string errorMessage = string.Empty;

        public Repository()
        {
            this._context = new JooleAppEntities();
            entities = _context.Set<T>();
        }
        public Repository(JooleAppEntities context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetbyId(int Id)
        {
            return entities.Find(Id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
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

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
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



    }
}

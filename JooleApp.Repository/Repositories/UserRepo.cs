using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using JooleApp.Domain;

namespace JooleApp.Repository.Repositories
{
    public class UserRepo : Repository<tblUser>
    {
        private JooleAppEntities _context = null;
        private DbSet<tblUser> entities = null;
        string errorMessage = string.Empty;

        public UserRepo()
        {
            this._context = new JooleAppEntities();
            entities = _context.Set<tblUser>();
        }

        public UserRepo(JooleAppEntities context)
        {
            _context = context;
            entities = _context.Set<tblUser>();
        }

        public IEnumerable<tblUser> GetUsers(int UserID)
        {
            List<tblUser> users = new List<tblUser>();
            using (var context = new JooleAppEntities())
            {
                users = new List<tblUser>().Where(u => u.userID == UserID).ToList<tblUser>();
            }
            return users;
        }


        public new void Insert(tblUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _context.SaveChanges();
        }

    }
   
}

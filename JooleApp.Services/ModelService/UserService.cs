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
    public class UserService
    {
        private UnitOfWork unitOfWork;
        
        private UserRepo userRepo;
        private Repository<tblUser> userRepo2;

        public UserService(UnitOfWork unitOfWork, UserRepo userRepo, Repository<tblUser> userRepo2)
        {
            this.unitOfWork = unitOfWork;
            this.userRepo = unitOfWork.UserRepo;
            this.userRepo2 = userRepo2;
        }

        public UserService()
        {
            this.unitOfWork = new UnitOfWork();
            this.userRepo = new UnitOfWork().UserRepo;
            this.userRepo2 = new Repository<tblUser>();
        }

        public IEnumerable<tblUser> GetAll()
        {
            return this.userRepo.GetAll();
        }

        public tblUser GetbyId(int Id)
        {
            return this.userRepo.GetbyId(Id);
        }

        public void Save(tblUser model)
        {
            this.userRepo.Save();
        }

        public void Delete(tblUser category)
        {
            this.userRepo.Delete(category);
        }

        public IEnumerable<tblUser> GetUsers(int userID)
        {
            return this.userRepo.GetAll().Where(model => model.userID == userID);
        }

        public IEnumerable<tblUser> GetUserAuth(string userName,string password)
        {
            return this.userRepo.GetAll().Where(model => model.userName == userName && model.password == password);
        }
        //public IEnumerable<tblUser> GetByPredicate(Func<IEnumerable<tblUser>, bool> predicate)
        //{
        //    return this.userRepo.FirstOrDefault(predicate);
        //}
        //public IEnumerable<tblUser> GetByPredicate(Func<IEnumerable<tblUser>, bool> predicate)
        //{
        //    return entities.FirstOrDefault(predicate);
        //}
    }
}

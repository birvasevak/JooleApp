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
    public class LoginService
    {
        private UserRepo userRepo;
        private Repository<tblUser> userProfileRepo;
    }
}

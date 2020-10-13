using JooleApp.Domain;
using JooleApp.Repository;
using JooleApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleApp.Services.ModelService
{
    public class SubCategoryService
    {
        private UnitOfWork unitOfWork;
        private ProductSubCategoryRepo catRepo;
        private Repository<tblSubCategory> subCatRepo;
    }
}

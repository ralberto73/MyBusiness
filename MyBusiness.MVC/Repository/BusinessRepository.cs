using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.MVC.Repository
{
    public class BusinessRepository : IBusinessRepository
    {
        private ApplicationDbContext _db;
        public BusinessRepository() //( ApplicationDbContext  dbContext)
        {
          //  _db = dbContext;

        }

        public  IEnumerable<Brand> GetAllBrands()  => new List<Brand> {
                                                                               new Brand { BrandId = "Acura" } };


    }
}

using MyBusiness.Data.Data.Repository;
using MyBusiness.Data.Data.Repository.IRepository;
using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            WorkOrder = new WorkOrdeRepository(_db);
        }

        public IWorkOrdeRepository WorkOrder { get; private set; }

        public IWorkOrdeRepository workOrder => throw new NotImplementedException();

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

using MyBusiness.Data.Data.Repository.IRepository;
using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.Data.Data.Repository
{
    public class WorkOrdeRepository :Repository<WorkOrder> , IWorkOrdeRepository
    {
        private readonly ApplicationDbContext _db;

        public WorkOrdeRepository( ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        void IWorkOrdeRepository.Update(WorkOrder workOrder)
        {
            _db.SaveChanges();
        }
    }
}

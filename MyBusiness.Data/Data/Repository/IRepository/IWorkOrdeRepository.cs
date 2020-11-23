using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.Data.Data.Repository.IRepository
{
    public interface IWorkOrdeRepository :  IRepository<WorkOrder>
    {
        //   Your Methoda

        void Update(WorkOrder workOrder);
    }
}

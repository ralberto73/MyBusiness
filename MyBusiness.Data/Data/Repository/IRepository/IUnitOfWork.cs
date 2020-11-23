using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.Data.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkOrdeRepository workOrder { get; }

        void Save();
    }
}

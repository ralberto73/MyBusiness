using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.DataAccess
{
    public class DataRepository
    {
        private string _connection_string;

        public WorkOrderRepository WorkOrders;
        public DataRepository( string connection_string )
        {
            _connection_string = connection_string;
            WorkOrders = new WorkOrderRepository(_connection_string);
        }
        
        
    }
}

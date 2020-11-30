using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.DataAccess
{
    public class BrandRepository
    {
        private string _connection_string;
        private AdoSqlHelper db = null;
        public BrandRepository(string connection_string)
        {
            this._connection_string = connection_string;
            db = new AdoSqlHelper(connection_string);
        }

        public  List<Brand> GetAll()
        {

            return db.GetListFromSp<Brand>("Brands_GetAll", null, null);
        }
    }
}

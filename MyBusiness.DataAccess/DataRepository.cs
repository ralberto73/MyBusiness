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

        
        public DataRepository( string connection_string )
        {
            _connection_string = connection_string;
        }

        public async Task GetAllAsync() 
        {
            using (SqlConnection sql = new SqlConnection(_connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("GetWorkOrders", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@From",DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@To",  DateTime.Now));
                   // var response = new List<Value>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var a = reader.GetColumnSchema();
                            var r = MapValues<WorkOrder1>(reader);
                        }
                    }

                   // return response;
                }
            }
        }
        /*
        public async Task<List<Value>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllValues", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Value>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        } */

        private T MapValues<T>(SqlDataReader reader) where T : new()
        {
            T result = new T();
            // var columnShemas = ;

            foreach (var schema in reader.GetColumnSchema())
            {
                var property_name = schema.ColumnName.Trim();
                var type = result.GetType();
                // Get the PropertyInfo object by passing the property name.
                PropertyInfo myPropInfo = type.GetProperty(property_name);
                if (myPropInfo != null)
                    // Fill  the property.
                    myPropInfo.SetValue( result, reader[property_name], null);
            }
            return result;
        }
    }
}

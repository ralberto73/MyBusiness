using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                            //response.Add(MapToValue(reader));
                            var a = reader[0];
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

        private Value MapToValue<(SqlDataReader reader , )
        {
            return new Value()
            {
                Id = (int)reader["Id"],
                Value1 = (int)reader["Value1"],
                Value2 = reader["Value2"].ToString()
            };
        } */

        private T MapValues<T>(SqlDataReader reader) where T : new()
        {
            T result = new T();
            //for (int i = 0; i < myPropertyInfo.Length; i++)
            //{
            //    Console.WriteLine(myPropertyInfo[i].ToString());
            //}

            return result;
        }
    }
}

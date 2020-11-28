using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBusiness.DataAccess
{
    public class AdoSqlHelper : IAdoSqlHelper
    {

        private SqlConnection _connection = null;
        private string _connection_string = string.Empty;

        public AdoSqlHelper(string connection_string)
        {
            /* string connectionString = ConfigurationManager.ConnectionStrings["AceKingSuitedDB"].ConnectionString;
             _connection = new SqlConnection(connectionString);
             _connection.Open();*/
            _connection_string = connection_string;

        }

        public List<T> GetListFromSp<T>(string procedure_name, List<SqlParameter> sql_parameters, params object[] params_values) where T : new()
        {
            List<T> result_list = new List<T>();

            using (SqlConnection sql = new SqlConnection(_connection_string))
            {
                using (SqlCommand cmd = new SqlCommand(procedure_name, sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //  Fills  All Sp Parameters
                    if (sql_parameters != null && sql_parameters.Count > 0 && sql_parameters.Count == params_values.Length)
                    {
                        foreach (SqlParameter parameter in sql_parameters)
                        {
                            cmd.Parameters.Add(parameter);
                            cmd.Parameters[parameter.ParameterName].Value = params_values[0];
                        }
                    }
                    sql.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //   var a = reader.GetColumnSchema();
                            var r = MapValues<T>(reader);
                            result_list.Add(r);
                        }
                    }
                }
            }
            return result_list;
        }

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
                    myPropInfo.SetValue(result, reader[property_name], null);
            }
            return result;
        }

        /*     public SqlConnection DBConnection
           {
             get
               {
                   if (_connection.State == ConnectionState.Connecting)
                   {
                       while (_connection.State == ConnectionState.Connecting)
                           Thread.Sleep(1000);
                   }
                   if (_connection.State != ConnectionState.Open)
                       _connection.Open(); 

                   return _connection;
               }
           }
    */
    }
}

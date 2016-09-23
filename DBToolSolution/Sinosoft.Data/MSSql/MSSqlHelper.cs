using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sinosoft.Data;
using System.Data.SqlClient;
using Sinosoft.Model;
using System.Data;
namespace Sinosoft.Data.MSSql
{
    public class MSSqlHelper
    {
        public List<DataAttrEntity> Read(string commstr, int MSSQLDB)
        {
            try
            {
                List<DataAttrEntity> Entity = new List<DataAttrEntity>();
                using (SqlConnection sc = new SqlConnection(ConnectionDB.ConnectionMSSqlDB(MSSQLDB)))
                {
                    sc.Open();
                    if (sc.State == ConnectionState.Open)
                    {
                        SqlCommand comm = new SqlCommand(commstr, sc);
                        SqlDataReader read = comm.ExecuteReader();
                        while (read.Read())
                        {
                            DataAttrEntity attribute = new DataAttrEntity();
                            attribute.ColumnName = (string)read["ColumnName"];
                            attribute.TypeLength = (Int16)read["TypeLength"];
                            attribute.ValueType = (string)read["ValueType"];
                            Entity.Add(attribute);

                        }
                        return Entity;
                    }
                    throw new Exception("MSSQL数据库连接失败！");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            
        }
        public int Run_sql(string commandtext, int MSSQLDB)
        {
            int result;
            try
            {
                using (SqlConnection sc = new SqlConnection(ConnectionDB.ConnectionMSSqlDB(MSSQLDB)))
                {
                    sc.Open();
                    SqlCommand comm = new SqlCommand(commandtext, sc);
                    result = comm.ExecuteNonQuery();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

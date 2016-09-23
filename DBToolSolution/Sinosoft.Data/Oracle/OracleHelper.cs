using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using Sinosoft.Model;
namespace Sinosoft.Data.Oracle
{
    public class OracleHelper
    {
        public List<DataAttrEntity> Read(string connstr, int OracleDB)
        {
            try
            {
                using (OracleConnection oc = new OracleConnection(ConnectionDB.ConnectionOracleDB(OracleDB)))
                {
                    oc.Open();
                    List<DataAttrEntity> Entity = new List<DataAttrEntity>();
                    if (oc.State == ConnectionState.Open)
                    {
                        Console.WriteLine("数据库连接打开");
                        OracleCommand comm = new OracleCommand(connstr, oc);
                        OracleDataReader read = comm.ExecuteReader();
                        while (read.Read())
                        {
                            DataAttrEntity attribute = new DataAttrEntity();
                            attribute.ColumnName = (string)read["ColumnName"];
                            attribute.TypeLength = (decimal)read["TypeLength"];
                            attribute.ValueType = (string)read["ValueType"];
                            Entity.Add(attribute);
                        }
                        return Entity;
                    }
                    throw new Exception("ORACLE数据库连接失败！");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int Run_sql(string commandtext, int ORACLEDB)
        {
            int result;
            try
            {
                using (OracleConnection sc = new OracleConnection(ConnectionDB.ConnectionOracleDB(ORACLEDB)))
                {
                    sc.Open();
                    OracleCommand comm = new OracleCommand(commandtext, sc);
                    result = comm.ExecuteNonQuery();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return result;
        }
    }
}

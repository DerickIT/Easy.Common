using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace Sinosoft.Data
{
    public static class ConnectionDB
    {

        /// <summary>
        /// 1是读取emis目标库，
        /// -1是读取lifepro目标库
        /// </summary>
        /// <param name="MSSQLDB"></param>
        /// <returns></returns>
        public static string ConnectionMSSqlDB(int MSSQLDB)
        {
            try
            {
                string connstr = string.Empty;
                if (MSSQLDB == 1)
                    connstr = ConfigurationManager.ConnectionStrings["MSSQLConnectionString1"].ConnectionString;
                else if (MSSQLDB == -1)
                    connstr = ConfigurationManager.ConnectionStrings["MSSQLConnectionString-1"].ConnectionString;
                return connstr;
            }
            catch (Exception EX)
            {

                throw EX;
            }
        }
        /// <summary>
        /// 1是emis源库
        /// -1是lifepro源库，
        /// 2是读emis镜像库，
        /// -2是lifepro镜像库
        /// </summary>
        /// <param name="ORACLEDB"></param>
        /// <returns></returns>
        public static string ConnectionOracleDB(int ORACLEDB)
        {

            string connstr = string.Empty;
            try
            {
                if (ORACLEDB == 1)
                    connstr = ConfigurationManager.ConnectionStrings["ORACLEConnectionString1"].ConnectionString;
                else if (ORACLEDB == -1)
                    connstr = ConfigurationManager.ConnectionStrings["ORACLEConnectionString-1"].ConnectionString;
                else if (ORACLEDB == 2)
                    connstr = ConfigurationManager.ConnectionStrings["ORACLE2ConnectionString2"].ConnectionString;
                else if (ORACLEDB == -2)
                    connstr = ConfigurationManager.ConnectionStrings["ORACLE2ConnectionString-2"].ConnectionString;
                return connstr;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

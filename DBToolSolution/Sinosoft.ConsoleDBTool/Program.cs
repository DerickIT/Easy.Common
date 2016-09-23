using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Sinosoft.Common;
using Sinosoft.Data.MSSql;
using Sinosoft.Data.Oracle;
using Sinosoft.ValidLibrary;
using Sinosoft.Output;
namespace Sinosoft.ConsoleDBTool
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string SaveAddress = ConfigurationManager.AppSettings["SaveAddress"];
                Console.WriteLine("请输入要执行的操作编号：1、oracle  TO Sql Server 2012 ；2、oracle To oracle");
                var sinosoft = ConfigurationManager.GetSection("sinosoft") as SinosoftConfigure;
                if (sinosoft != null)
                {
                    var TableList = sinosoft.DBtable.ToList();
                    if (TableList != null && TableList.Count > 0)
                    {
                        var Select = Console.ReadLine();
                        var OC = new ValidFunc();
                        var VC = new ValidClass();
                       
                        if (Select == "1")
                        {
                            WriteOutput.IsExist(SaveAddress, "MSSQL");
                            Console.WriteLine("oracle TO Sql Server 2012 库表结构操作");
                            var MS = new MSSqlHelper();
                            var OHELP = new OracleHelper();
                            for (int i = 0; i < TableList.Count; i++)
                            {
                                string MSSqlcommtext = string.Format(@"select syscolumns.name ColumnName, UPPER(systypes.name) ValueType, syscolumns.length TypeLength from syscolumns   
  left join systypes on syscolumns.xusertype =systypes.xusertype 
  where id=(select id from sysobjects where name='{0}') order by syscolumns.name", TableList[i].TableName);
                                string Oraclecommtext = string.Format(@"select COLUMN_NAME ColumnName, DATA_TYPE ValueType,DATA_LENGTH TypeLength 
from user_tab_columns where Table_Name='{0}' order by column_name", TableList[i].TableName);
                                var Blist = MS.Read(MSSqlcommtext);
                                var Alist = OHELP.Read(Oraclecommtext, true);
                                OC.ValidOracleHelper(TableList[i].TableName, Alist, Blist, (T, A, B) => VC.VolidOracleToMSSql(T, A, B), (S, D) => VC.VolidAddMSSql(S, D));
                                Console.WriteLine("已生成执行【oracle TO Sql Server 2012 库表结构操作】sql！  按任意键退出！");
                                Console.ReadKey();
                            }

                        }
                        else if (Select == "2")
                        {
                            Console.WriteLine("oracle TO oracle 库表结构操作");
                            var OHELP = new OracleHelper();
                            WriteOutput.IsExist(SaveAddress, "ORACLE");
                            for (int i = 0; i < TableList.Count; i++)
                            {
                                string Oraclecommtext = string.Format(@"select COLUMN_NAME ColumnName, DATA_TYPE ValueType,DATA_LENGTH TypeLength 
from user_tab_columns where Table_Name='{0}' order by column_name", TableList[i].TableName);
                                var Alist = OHELP.Read(Oraclecommtext, true);
                                var Blist = OHELP.Read(Oraclecommtext, false);
                                OC.ValidOracleHelper(TableList[i].TableName, Alist, Blist, (T, A, B) => VC.VolidOracleToOracle(T, A, B), (S, D) => VC.VolidAddOracle(S, D));
                                Console.WriteLine("已生成执行【oracle TO oracle 库表结构操作】sql！  按任意键退出！");
                                Console.ReadKey();
                            }
                        }
                    }
                }





            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}

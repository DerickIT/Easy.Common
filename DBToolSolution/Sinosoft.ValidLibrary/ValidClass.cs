using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sinosoft.Model;
using Sinosoft.Output;
namespace Sinosoft.ValidLibrary
{
    public class ValidClass
    {
        #region Oracle对比方法
        public void VolidOracleToMSSql(string TableName, DataAttrEntity Oracle, DataAttrEntity MSSql,string SaveAddress)
        {
            string a = string.Empty;
            ValidColumns com = new ValidColumns();
            switch (Oracle.ValueType)
            {
                case "CHAR":
                    com.CHARFunc(TableName, MSSql,SaveAddress);
                    break;
                case "VARCHAR2":
                    com.VARCHAR2Func(TableName, MSSql,SaveAddress);
                    break;
                case "NCHAR":
                    com.NCHARFunc(TableName, MSSql,SaveAddress);
                    break;
                case "NVARCHAR2":
                    com.NVARCHAR2Func(TableName, MSSql,SaveAddress);
                    break;
                case "DATE":
                    com.DATEFunc(TableName, MSSql,SaveAddress);
                    break;
                case "LONG":
                    com.LONGFunc(TableName, MSSql,SaveAddress);
                    break;
                case "RAW":
                    com.RAWFunc(TableName, MSSql,SaveAddress);
                    break;
                case "LONG RAW":
                    com.LONGRAWFunc(TableName, MSSql,SaveAddress);
                    break;
                case "BLOB":
                    com.BLOBFunc(TableName, MSSql,SaveAddress);
                    break;
                case "CLOB":
                    com.CLOBFunc(TableName, MSSql,SaveAddress);
                    break;
                case "NCLOB":
                    com.NCLOBFunc(TableName, MSSql,SaveAddress);
                    break;
                case "NUMBER":
                    com.NUMBERFunc(TableName, MSSql,SaveAddress);
                    break;
                case "DECIMAL":
                    com.DECIMALFunc(TableName, MSSql,SaveAddress);
                    break;
                default:
                    break;
            }
        }
        public void VolidOracleToOracle(string TableName, DataAttrEntity AOracle, DataAttrEntity BOracle,string SaveAddress)
        {
            var Write = new WriteOutput("ORACLE");

            if (AOracle.ColumnName != BOracle.ColumnName)
            {
                //生成为boracle添加的语句  

                if (AOracle.ValueType != "DATE" && AOracle.ValueType != "LONG" && AOracle.ValueType != "LONG RAW" && AOracle.ValueType != "BLOB" && AOracle.ValueType != "CLOB" && AOracle.ValueType != "NCLOB")
                {
                    Write.Write(string.Format("ALTER TABLE {0} ADD {1} {2}({3}) ", TableName, AOracle.ColumnName, AOracle.ValueType, AOracle.TypeLength), "ORACLE", SaveAddress);
                }
                else
                {
                    Write.Write(string.Format("ALTER TABLE {0} ADD {1} {2} ", TableName, AOracle.ColumnName, AOracle.ValueType), "ORACLE",SaveAddress);
                }

            }
            else
            {
                if (AOracle.ValueType != AOracle.ValueType)
                {
                    ValidDataType(TableName, AOracle, Write, SaveAddress);
                }
                else
                {
                    if (AOracle.TypeLength != AOracle.TypeLength)
                    {
                        ValidDataType(TableName, AOracle, Write, SaveAddress);
                        //Write.Write(string.Format("ALTER TABLE {0} MODIFY {1} {2}({3})", TableName, AOracle.ColumnName, AOracle.ValueType, AOracle.TypeLength));
                    }
                }
            }
        }

        #endregion

        #region Oracle增加方法
        public void VolidAddMSSql(string TableName, DataAttrEntity Oracle,string SaveAddress)
        {
            var WL = new WriteOutput("MSSql");
            if (Oracle.ValueType == "CHAR")
            {
                //判断是什么字段然后根据大小处理成可调用的mssql语句

                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2} ({3})", TableName, Oracle.ColumnName, "CHAR", Oracle.TypeLength),"MSSql",SaveAddress);
            }
            else if (Oracle.ValueType == "VARCHAR2")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2} ({3})", TableName, Oracle.ColumnName, "VARCHAR", Oracle.TypeLength), "MSSql", SaveAddress);
            }
            else if (Oracle.ValueType == "NCHAR")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2} ({3})", TableName, Oracle.ColumnName, "NCHAR", Oracle.TypeLength), "MSSql", SaveAddress);
            }
            else if (Oracle.ValueType == "NVARCHAR2")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2} ({3})", TableName, Oracle.ColumnName, "NVARCHAR", Oracle.TypeLength), "MSSql", SaveAddress);
            }
            else if (Oracle.ValueType == "DATE" || Oracle.ValueType == "DATETIME")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n  ADD {1} {2}", TableName, Oracle.ColumnName, "DATETIME"), "MSSql", SaveAddress);
            }
            else if (Oracle.ValueType == "LONG")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2} ", TableName, Oracle.ColumnName, "TEXT"), "MSSql", SaveAddress);
            }
            else if (Oracle.ValueType == "RAW")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2} ({3})", TableName, Oracle.ColumnName, "VARBINARY", Oracle.TypeLength), "MSSql", SaveAddress);
            }
            else if (Oracle.ValueType == "LONG RAW")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2} ({3})", TableName, Oracle.ColumnName, "VARBINARY", Oracle.TypeLength), "MSSql", SaveAddress);
            }
            else if (Oracle.ValueType == "BLOB")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2}", TableName, Oracle.ColumnName, "IMAGE"), "MSSql", SaveAddress);
            }
            else if (Oracle.ValueType == "CLOB")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2}", TableName, Oracle.ColumnName, "TEXT"), "MSSql", SaveAddress);
            }
            else if (Oracle.ValueType == "NCLOB")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2}", TableName, Oracle.ColumnName, "TEXT"), "MSSql", SaveAddress);
            }
            else if (Oracle.ValueType == "NUMBER")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2}", TableName, Oracle.ColumnName, "INT"), "MSSql", SaveAddress);
            }
            else if (Oracle.ValueType == "DECIMAL")
            {
                WL.Write(string.Format("ALTER TABLE {0}\r\n ADD {1} {2} ({3})", TableName, Oracle.ColumnName, "DECIMAL", Oracle.TypeLength), "MSSql", SaveAddress);
            }
        }
        public void VolidAddOracle(string TableName, DataAttrEntity AOracle, string SaveAddress)
        {
            var Write = new WriteOutput("ORACLE");
            if (AOracle.ValueType != "DATE" && AOracle.ValueType != "LONG" && AOracle.ValueType != "LONG RAW" && AOracle.ValueType != "BLOB" && AOracle.ValueType != "CLOB" && AOracle.ValueType != "NCLOB")
            {
                Write.Write(string.Format("ALTER TABLE {0} ADD {1} {2}({3}) ", TableName, AOracle.ColumnName, AOracle.ValueType, AOracle.TypeLength), "ORACLE", SaveAddress);
            }
            else
            {
                Write.Write(string.Format("ALTER TABLE {0} ADD {1} {2} ", TableName, AOracle.ColumnName, AOracle.ValueType), "ORACLE", SaveAddress);
            }

        }
        #endregion



        /// <summary>
        /// 验证字段类型，输出是否包含类型长度的语句
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="AOracle"></param>
        /// <param name="Write"></param>
        private static void ValidDataType(string TableName, DataAttrEntity AOracle, WriteOutput Write, string SaveAddress)
        {
            if (AOracle.ValueType != "DATE" && AOracle.ValueType != "LONG" && AOracle.ValueType != "LONG RAW" && AOracle.ValueType != "BLOB" && AOracle.ValueType != "CLOB" && AOracle.ValueType != "NCLOB")
            {
                Write.Write(string.Format("ALTER TABLE {0} MODIFY {1} {2}({3})", TableName, AOracle.ColumnName, AOracle.ValueType, AOracle.TypeLength), "ORACLE", SaveAddress);
            }
            else
            {
                Write.Write(string.Format("ALTER TABLE {0} MODIFY {1} {2}", TableName, AOracle.ColumnName, AOracle.ValueType), "ORACLE", SaveAddress);
            }
        }
    }
}

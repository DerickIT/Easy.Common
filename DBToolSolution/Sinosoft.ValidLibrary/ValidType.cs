using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sinosoft.Output;
using Sinosoft.Model;
namespace Sinosoft.ValidLibrary
{
    public class ValidType
    {
        public void ValidTypeText(string TableName, string ColumnType, string TypeLength, string SaveAddress)
        {
            var Write = new WriteOutput("MSSQL");
            if (ColumnType == "CHAR")
            {
                //char可以转换成
                //已经确定是char，然后直接拿着表名alter 列名 类型长度就可以
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2}", TableName, ColumnType, TypeLength);
                Write.Write(commtext, "MSSql",SaveAddress); 
            }
            else if (ColumnType == "VARCHAR")
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2}", TableName, ColumnType, TypeLength);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
            else if (ColumnType == "NCAHR")
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2}", TableName, ColumnType, TypeLength);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
            else if (ColumnType == "NVARCHAR")
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2}", TableName, ColumnType, TypeLength);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
            else if (ColumnType == "DATE")
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1}", TableName, ColumnType);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
            else if (ColumnType == "DATETIME")
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1}", TableName, ColumnType);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
            else if (ColumnType == "VARBINARY")
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2}", TableName, ColumnType, TypeLength);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
            else if (ColumnType == "IMAGE")
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1}", TableName, ColumnType);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
            else if (ColumnType == "TEXT")
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1}", TableName, ColumnType);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
            else if (ColumnType == "INT")
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1}", TableName, ColumnType);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
            else if (ColumnType == "DECIMAL")
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1}}", TableName, ColumnType);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sinosoft.Model;
using Sinosoft.Output;
namespace Sinosoft.ValidLibrary
{
    public class ValidColumns
    {


        WriteOutput Write = new WriteOutput("MSSQL");
        public void CHARFunc(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "CHAR")
            {
                //类型相同，不需要更改
            }
            else
            {
                //生成alter table name,等语句，写入到文件中
                //直接修改成char
                string commtext = String.Format("alter table {0} \r\n alter column {1} {2} {3}", TableName, Blist.ColumnName, Blist.ValueType, Blist.TypeLength);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
        }
        public void VARCHAR2Func(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "VARCHAR")
            {
                //类型相同，不需要更改
            }
            else
            {
                //生成alter table name,等语句，写入到文件中
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2} {3}", TableName, Blist.ColumnName, Blist.ValueType, Blist.TypeLength);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
        }
        public void NCHARFunc(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "NCHAR")
            {
                //类型相同，不需要更改
            }
            else
            {
                //生成alter table name,等语句，写入到文件中
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2} {3}", TableName, Blist.ColumnName, Blist.ValueType, Blist.TypeLength);
                Write.Write(commtext, "MSSql",SaveAddress);;
            }
        }
        public void NVARCHAR2Func(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "NVARCHAR")
            {
                //类型相同，不需要更改
            }
            else
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2} {3}", TableName, Blist.ColumnName, Blist.ValueType, Blist.TypeLength);
                Write.Write(commtext, "MSSql",SaveAddress);;
                //生成alter table name,等语句，写入到文件中
            }
        }
        public void DATEFunc(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "DATETIME" || Blist.ValueType == "DATE")
            {
                //类型相同，不需要更改
            }
            else
            {
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2}", TableName, Blist.ColumnName, "DATETIME");
                Write.Write(commtext, "MSSql",SaveAddress);
                //生成alter table name,等语句，写入到文件中
            }
        }
        public void LONGFunc(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "TEXT")
            {
                //类型相同，不需要更改
            }
            else
            {
                //生成alter table name,等语句，写入到文件中
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2} ", TableName, Blist.ColumnName, "TEXT");
                Write.Write(commtext, "MSSql",SaveAddress);
            }
        }
        public void RAWFunc(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "VARBINARY")
            {
                //类型相同，不需要更改
            }
            else
            {
                //生成alter table name,等语句，写入到文件中
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2} {3}", TableName, Blist.ColumnName, "VARBINARY", Blist.TypeLength);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
        }
        public void LONGRAWFunc(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "VARBINARY" || Blist.ValueType == "IMAGE")//varbinary/image(判断字节大小)
            {
                //类型相同，不需要更改
            }
            else
            {
                //生成alter table name,等语句，写入到文件中
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2}", TableName, Blist.ColumnName, "IMAGE");
                Write.Write(commtext, "MSSql",SaveAddress);;
            }
        }
        public void BLOBFunc(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "IMAGE")
            {
                //类型相同，不需要更改
            }
            else
            {
                //生成alter table name,等语句，写入到文件中
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2}", TableName, Blist.ColumnName, "IMAGE");
                Write.Write(commtext, "MSSql",SaveAddress);;
            }
        }
        public void CLOBFunc(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "TEXT")
            {
                //类型相同，不需要更改
            }
            else
            {
                //生成alter table name,等语句，写入到文件中
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2}", TableName, Blist.ColumnName, "TEXT");
                Write.Write(commtext, "MSSql",SaveAddress);;
            }
        }
        public void NCLOBFunc(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "TEXT" || Blist.ValueType == "VARCHAR")
            {
                //类型相同，不需要更改
            }
            else
            {
                //生成alter table name,等语句，写入到文件中
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2}", TableName, Blist.ColumnName, "TEXT");
                Write.Write(commtext, "MSSql",SaveAddress);;
            }
        }
        public void NUMBERFunc(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "INT" || Blist.ValueType == "DECIMAL")
            {
                //类型相同，不需要更改
            }
            else
            {
                //生成alter table name,等语句，写入到文件中
                string commtext = String.Format("\r\n alter table {0} \r\n alter column  {1} {2}", TableName, Blist.ColumnName, "INT");
                Write.Write(commtext, "MSSql",SaveAddress);;
            }
        }
        public void DECIMALFunc(string TableName, DataAttrEntity Blist, string SaveAddress)
        {
            if (Blist.ValueType == "DECIMAL" || Blist.ValueType == "INT")
            {
                //类型相同，不需要更改
            }
            else
            {
                //生成alter table name,等语句，写入到文件中
                string commtext = String.Format("\r\n alter table {0} \r\n alter column {1} {2} {3}", TableName, Blist.ColumnName, "DECIMAL", Blist.TypeLength);
                Write.Write(commtext, "MSSql",SaveAddress);
            }
        }

    }
}

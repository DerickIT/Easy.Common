using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
namespace Sinosoft.Output
{
    public class WriteOutput
    {
        string DBSQLAddress = string.Empty;
        public WriteOutput(string DB)
        {

        }
        public void Write(string text, string DB, string SaveAddress)
        {
            try
            {
                //SaveAddress = ConfigurationManager.AppSettings["SaveAddress"];
                DBSQLAddress = SaveAddress + "\\" + (DB) + DateTime.Now.ToString("yyyy-MM-dd") + ".sql";
                using (StreamWriter sw = new StreamWriter(DBSQLAddress, true, Encoding.Default))
                {
                   
                    //开始写入
                    sw.WriteLine(text);
                    //清空缓冲区
                    sw.Flush();
                    //关闭流
                    sw.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void IsExist(string SaveAddress, string DB)
        {
            string path = SaveAddress + "\\" + (DB) + DateTime.Now.ToString("yyyy-MM-dd") + ".sql";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

        }
    }
}

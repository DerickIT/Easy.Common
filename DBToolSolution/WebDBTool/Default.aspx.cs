using Sinosoft.Common;
using Sinosoft.Data.MSSql;
using Sinosoft.Data.Oracle;
using Sinosoft.Output;
using Sinosoft.ValidLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebDBTool
{
    public partial class _Default : System.Web.UI.Page
    {
        public static int ORACLEDB, MSSQLDB, ORACLEDB2 = 0;
        public static int IsDB = 0;
        string SaveAddress = string.Empty;
        public static SinosoftConfigure sinosoft = new SinosoftConfigure();
        ValidFunc OC = new ValidFunc();
        ValidClass VC = new ValidClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sinosoft = ConfigurationManager.GetSection("sinosoft") as SinosoftConfigure;
            }
            SaveAddress = Server.MapPath("\\BackUpSQL");
        }

        protected List<string> ResultTableName()
        {
            List<string> list = new List<string>();
            foreach (RepeaterItem item in dbtable.Items)
            {
                CheckBox cb = (CheckBox)item.FindControl("checkon");
                if (cb != null && cb.Checked == true)
                {
                    list.Add(cb.Text);
                }
            }
            return list;
        }

        /// <summary>
        /// 填充到文本框
        /// </summary>
        /// <param name="SQLName"></param>
        private bool DownLoadSQL(string SQLName)
        {
            //IsDB为11时，执行库为镜像库，为12时执行库为目标库
            //现在改为11为emis镜像库，-11为lifepro镜像库||12为emis目标库，-12为lifepro目标库
            if (!string.IsNullOrEmpty(SQLName))
            {
                if (SQLName == "ORACLE")
                    IsDB = 11;
                else if (SQLName == "MSSQL")
                    IsDB = 12;
                //else if (SQLName == "ORACLE-1")
                //    IsDB = -11;
                //else if (SQLName == "MSSQL-1")
                //    IsDB = -12;
            }
            string filePath = Server.MapPath("\\BackUpSQL\\" + SQLName + DateTime.Now.ToString("yyyy-MM-dd") + ".sql");
            if (File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.Open);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                this.sqli.Value = File.ReadAllText(filePath, System.Text.Encoding.UTF8);

                //Response.ContentType = "application/octet-stream";
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode("" + SQLName + ".sql", System.Text.Encoding.UTF8));
                //Response.BinaryWrite(bytes);
                //Response.Flush();
                //Response.End();
                return true;
            }
            return false;
        }

        protected void oracleTooracle_Click(object sender, EventArgs e)
        {
            try
            {

                if (sinosoft != null)
                {
                    var TableList = ResultTableName();
                    if (TableList != null && TableList.Count > 0)
                    {
                        var OC = new ValidFunc();
                        var VC = new ValidClass();
                        var OHELP = new OracleHelper();
                        WriteOutput.IsExist(SaveAddress, "ORACLE");
                        for (int i = 0; i < TableList.Count; i++)
                        {
                            string Oraclecommtext = string.Format(@"select COLUMN_NAME ColumnName, DATA_TYPE ValueType,DATA_LENGTH TypeLength 
            from user_tab_columns where Table_Name='{0}' order by column_name", TableList[i]);
                            var Alist = OHELP.Read(Oraclecommtext, ORACLEDB);
                            var Blist = OHELP.Read(Oraclecommtext, ORACLEDB2);
                            OC.ValidOracleHelper(TableList[i], Alist, Blist, (T, A, B) => VC.VolidOracleToOracle(T, A, B, SaveAddress), (S, D) => VC.VolidAddOracle(S, D, SaveAddress));
                        }
                        if (DownLoadSQL("ORACLE"))
                            Response.Write("<script Language=JavaScript>alert('已在文本框中生成执行【oracle TO oracle 库表结构操作】sql！')</script>");
                        else
                        {
                            Response.Write("<script Language=JavaScript>alert('两个oracle数据库库表结构一致！')</script>");
                            this.sqli.Value = "";
                        }
                    }
                    else
                        Response.Write("<script Language=JavaScript>alert('请选择要处理的表！')</script>");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void oracleTomssql_Click(object sender, EventArgs e)
        {
            try
            {

                var MS = new MSSqlHelper();
                var OHELP = new OracleHelper();
                var TableList = ResultTableName();
                if (TableList != null && TableList.Count > 0)
                {
                    WriteOutput.IsExist(SaveAddress, "MSSQL");
                    for (int i = 0; i < TableList.Count; i++)
                    {
                        string MSSqlcommtext = string.Format(@"select syscolumns.name ColumnName, UPPER(systypes.name) ValueType, syscolumns.length TypeLength from syscolumns   
                          left join systypes on syscolumns.xusertype =systypes.xusertype 
                          where id=(select id from sysobjects where name='{0}') order by syscolumns.name", TableList[i]);
                        string Oraclecommtext = string.Format(@"select COLUMN_NAME ColumnName, DATA_TYPE ValueType,DATA_LENGTH TypeLength 
                        from user_tab_columns where Table_Name='{0}' order by column_name", TableList[i]);
                        var Alist = OHELP.Read(Oraclecommtext, ORACLEDB);
                        var Blist = MS.Read(MSSqlcommtext, MSSQLDB);
                        OC.ValidOracleHelper(TableList[i], Alist, Blist, (T, A, B) => VC.VolidOracleToMSSql(T, A, B, SaveAddress), (S, D) => VC.VolidAddMSSql(S, D, SaveAddress));
                    }
                    if (DownLoadSQL("MSSQL"))
                        Response.Write("<script Language=JavaScript>alert('已在文本框中生成执行【oracle TO Sql Server 2012 库表结构操作】sql！')</script>");
                    else
                    {
                        Response.Write("<script Language=JavaScript>alert('oracle To Sql Server 2012库表结构一致！')</script>");
                        this.sqli.Value = "";
                    }
                }
                else
                    Response.Write("<script Language=JavaScript>alert('请选择要处理的表！')</script>");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void run_Click(object sender, EventArgs e)
        {
            var MSHELP = new MSSqlHelper();
            var OHELP = new OracleHelper();
            //判断下执行oracle语句还是sqlserver语句
            var sql = this.sqli.Value;
            //执行语句到数据库
            if (IsDB == 11)
            {
                OHELP.Run_sql(sql, ORACLEDB2);
                Response.Write("<script Language=JavaScript>alert('sql语句已经在oracle镜像库中执行！')</script>");

            } if (IsDB == 12)
            {
                MSHELP.Run_sql(sql, MSSQLDB);
                Response.Write("<script Language=JavaScript>alert('sql语句已经在sqlserver目标库中执行！')</script>");
            }
            if (IsDB == 0)
            {
                Response.Write("<script Language=JavaScript>alert('未能成功执行sql语句！')</script>");
            }

        }


        protected void EMIS_Button_Click(object sender, EventArgs e)
        {
            ORACLEDB = 1; MSSQLDB = 1; ORACLEDB2 = 2; this.sqli.Value = "";
            dbtable.DataSource = sinosoft.DBtable.ToList();
            dbtable.DataBind();
        }

        protected void LifePro_Button_Click(object sender, EventArgs e)
        {
            ORACLEDB = -1; MSSQLDB = -1; ORACLEDB2 = -2; this.sqli.Value = "";
            dbtable.DataSource = sinosoft.DBtable1.ToList();
            dbtable.DataBind();
        }




    }
}
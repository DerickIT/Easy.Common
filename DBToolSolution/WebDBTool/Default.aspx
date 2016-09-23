<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebDBTool._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        table {
            border-collapse: collapse;
            border: 1px solid #000;
        }

        td {
            border-bottom: 1px solid #000;
        }

        textarea {
            resize: none;
            width: 600px;
            height: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>在使用本工具前请查看程序根目录的DBTool使用说明文档</h2>
            <h3>请选择要处理的源库</h3>
            <%-- <asp:RadioButton ID="RadioEMIS" name="db" Text="EMIS库" runat="server" />
            <asp:RadioButton name="db" ID="RadioLifePro" Text="LifePro库" runat="server" />
            <asp:CheckBox ID="EMIS" Text="EMIS源库" runat="server"  Checked="false" OnInit="EMIS_Click" />
            <asp:CheckBox ID="LifePro" Text="LifePro源库" runat="server" />--%>
            <asp:Button ID="EMIS_Button" runat="server" Text="EMIS源库" OnClick="EMIS_Button_Click" />
            <asp:Button ID="LifePro_Button" runat="server" Text="LifePro源库" OnClick="LifePro_Button_Click" />
            <h3>请选择要处理的表：</h3>
            <table>
                <asp:Repeater ID="dbtable" runat="server">
                    <HeaderTemplate>
                        <tr>
                            <td>选择:表名
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:CheckBox ID="checkon" runat="server" Text='<%#Eval("TableName")%>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <p>
            </p>
            <asp:Button ID="oracleTomssql" runat="server" Text="oracle To mssql" OnClick="oracleTomssql_Click" />
            <asp:Button ID="oracleTooracle" runat="server" Text="oracle To oracle" OnClick="oracleTooracle_Click" />
            <p>
            </p>
            <textarea runat="server" id="sqli"></textarea></br>
            <asp:Button ID="run_sql" runat="server" Text="执行文本框中sql语句" OnClick="run_Click" />
        </div>
    </form>
</body>
</html>

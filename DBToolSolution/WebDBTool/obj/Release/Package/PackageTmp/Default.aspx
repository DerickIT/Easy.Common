<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebDBTool._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        table tr td {
            border: 1px solid red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>请选择要处理的表</h3>
            <table>
                <asp:Repeater ID="dbtable" runat="server">
                    <HeaderTemplate>
                        <tr>
                            <td>选择:表名</td>
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
            <asp:Button ID="oracleTomssql" runat="server" Text="oracle To mssql" OnClick="oracleTomssql_Click" />
            <asp:Button ID="oracleTooracle" runat="server" Text="oracle To oracle" OnClick="oracleTooracle_Click" />
        </div>
    </form>
</body>
</html>

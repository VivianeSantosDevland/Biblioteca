<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCliente.aspx.cs" Inherits="Biblioteca.FormCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            height: 156px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="cabecalho">
    <br /><br />
    </div>
    <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>&nbsp;
    <asp:TextBox ID="txtCodCliente" runat="server" Width="155px" Height="22px"></asp:TextBox><br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Nome:"></asp:Label>&nbsp;&nbsp;
    <asp:TextBox ID="txtNomeCliente" runat="server" Width="155px" Height="23px"></asp:TextBox>
    </form>
</body>
</html>

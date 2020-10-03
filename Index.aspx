<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Biblioteca.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Biblioteca</title>
    <style type="text/css">
        #Cabecalho
        {
            height: 52px;
        }
    </style>
</head>
<body style="height: 321px; width: 693px">
    <form id="form1" runat="server">
    <div id="Cabecalho">
    </div>
    <div id="Menu" style="height: 106px; width: 106px">
        <asp:Button ID="Button1" runat="server" Height="36px" Text="Clientes" 
            Width="108px" /><br />
        <asp:Button ID="Button2" runat="server" Height="36px" Text="Livros" 
            Width="108px" />
        <asp:Button ID="Button3" runat="server" Height="34px" Text="Empréstimos" 
            Width="108px" />
    </div> 
    </form>
    <br />
    <div style="height: 45px; margin-top: 66px;">
    </div>
</body>
</html>

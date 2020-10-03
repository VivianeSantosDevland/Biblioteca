<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormEmprestimo.aspx.cs" Inherits="Biblioteca.Telas.FormEmprestimo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Biblioteca_Empréstimo</title>
     <link href="../CSS/Biblioteca.css" rel="stylesheet" type="text/css" /><!--lincando a página css à atual-->
      <style type="text/css">
          .botoes {
              position: relative;
              /*align-items: center;*/
              width: 486px;
              margin-left: 12px;
              top: -21px;
              left: 29px;
              height: 76px;
              margin-right: 0px;
          }
    </style>
     
   
    <style type="text/css">
   #menu {
    border: thin solid Black;
    float: left;
    width: 15%;
    height: 2%;
    margin-top: 5%;
    background-color: red;
    margin-left: 30px;
    margin-bottom: 0px;
    text-align:center;
}
    </style>
    
}
</head>
<body>
    <form id="form4" runat="server">
        <div>
             <div id="cabecalho"> 
           <div id="img" align="center">
               <img src="../Imagens/icone_logo.png" alt="logo da biblioteca aberta" style="height: 109px; width: 113px; margin-top:4%"/>
                <h3 style="text-align: center; width: 523px; margin-left: 212px; font-size: 27px; height: 35px; position: relative; float: left; top: -53px; left: 0px;" 
                   align="center">Gerenciador Biblioteca Aberta</h3>   
               </div>
            <br/>
            </div>
        <div id="corpoprincipal">
             <div id="Menu">
     <a href="Index.aspx" style="background-color: transparent; padding:2px; margin:8px;">Home</a>&nbsp;
     <a href="FormCliente.aspx" style="background-color: transparent; padding:2px; margin:8px;">Cliente</a>&nbsp;
      <a href="FormEmprestimo.aspx" style="background-color: transparent; padding:2px; margin:8px;">Empréstimo</a>&nbsp;
      <a href="FormLivro.aspx" style="background-color: transparent; padding:2px; margin:8px;">Livros</a>
            </div>
            <div class="conteudo">
            <br />
                <br />
            <asp:Label ID="codigoEmp" Text="Código: " runat="server"></asp:Label>&nbsp;
            <asp:TextBox ID="txtCodigoEmp" runat="server" Enabled="False" Width="154px" Height="18px" style="margin-left: 0px"></asp:TextBox>
            <br /><br />
            <asp:Label ID="cliente" runat="server" Text="Cliente:" ></asp:Label>&nbsp;
            <asp:DropDownList ID="listCliente" runat="server" Enabled="False" Height="25px" 
                    Width="154px" OnSelectedIndexChanged="listCliente_SelectedIndexChanged"></asp:DropDownList>
            <br /><br />
                &nbsp;<asp:Label ID="livro" runat="server" Text="Livro: "></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="listLivro" runat="server" Enabled="False" Height="25px" 
                    Width="154px"></asp:DropDownList>
                &nbsp;
             <br /><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="dataEmp" runat="server" Text="Data: " ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtData" runat="server" Enabled="False" Width="154px" Height="17px" style="margin-left: 0px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton_Jcalendar" runat="server" Width="24px" Height="24px" ImageUrl="~/Imagens/calendar-512.png" OnClick="ImageButton1_Click" Enabled="False" />
                <br />
            <asp:Calendar ID="jcalendarEmp" runat="server" 
                    style= "margin-left: 29%; margin-top: 39px; margin-right: 0px;" Height="182px" Width="294px" 
                    Enabled="False" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="ShortMonth" OnSelectionChanged="jcalendarEmp_SelectionChanged" SelectedDate="2017-12-12" Visible="False">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                <DayStyle BackColor="#CCCCCC" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                <TodayDayStyle BackColor="#999999" ForeColor="White" />
                </asp:Calendar>
                    <br /><br />
                    <div class="botoes" style="clip: rect(auto, auto, inherit, auto)">
                    
                    <asp:Button ID="buttonNovoEmp" Text="Novo" runat="server"  Height="30px" 
                            Width="80px" 
                            style="margin-top: 32px; margin-left: 0px; background-color:#b49999;" 
                            onclick="buttonNovoEmp_Click"/>
                    <asp:Button ID="butonSalvarEmp" Text="Salvar" runat="server" Height="30px" 
                            Width="80px" 
                            style="margin-top: 32px; margin-left: 18px; background-color:#b49999;" 
                            Enabled="False" OnClick="butonSalvarEmp_Click" />
                    <asp:Button ID="buttonEditar" Text="Editar" runat="server"  Height="30px" 
                            Width="80px" 
                            style="margin-top: 32px; margin-left: 18px; background-color:#b49999;" 
                            Enabled="False" OnClick="buttonEditar_Click" />
                    <asp:Button ID="buttonExclui" Text="Excluir" runat="server"  Height="30px" 
                            Width="80px" 
                            style="margin-top: 32px; margin-left: 18px; background-color:#b49999;" 
                            Enabled="False" OnClick="buttonExclui_Click"/>
                    </div>
                 <br />
                 <asp:Label ID="lblLista" runat="server" Text ="Empréstimos"></asp:Label>
                    <asp:GridView ID="emprestimoGrid" runat="server" Height="188px" 
                    style="margin-left: 88px; margin-top: 41px;" Width="410px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="emprestimoGrid_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                            <ItemStyle Font-Italic="True" Font-Names="Calibri" Font-Size="Smaller" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
            </div>
            </div>
        </div>
    </form>
</body>
</html>

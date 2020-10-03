<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCliente.aspx.cs" Inherits="Biblioteca.FormCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Biblioteca_Clientes</title>
    <link href="../CSS/Biblioteca.css" rel="stylesheet" type="text/css" />
    <!--lincando a página css à atual-->

    <style type="text/css">
        .botoes {
            position: relative;
            align-items: center;
            width: 400px;
            margin-left: 12px;
            top: 4px;
            left: 58px;
            height: 71px;
            margin-right: 0px;
        }

        .conteudo {
            background-color: #e0c7c7;
            width: 586px;
            height: 1204px;
            margin-left: 170px;
            margin-top: 44px;
            margin-right: 32px;
        }
    </style>

</head>
<body>
    <form id="form2" runat="server">
        <div id="cabecalho" align="left">
            <div id="img">
                <img src="../Imagens/icone_logo.png" alt="logo da biblioteca aberta" style="height: 109px; width: 113px; margin-top: 4%;" />
                <h3 style="text-align: center; width: 523px; margin-left: 212px; position: relative; float: left; font-size: 27px; top: -45px; left: 0px; height: 79px;"
                    align="center">Gerenciador Biblioteca Aberta</h3>
            </div>
        </div>
        <div id="corpoprincipal">
            <div id="Menu">
                <a href="Index.aspx" style="background-color: transparent; padding: 2px; margin: 8px;">Home</a>&nbsp;
     <a href="FormCliente.aspx" style="background-color: transparent; padding: 2px; margin: 8px;">Cliente</a>&nbsp;
      <a href="FormEmprestimo.aspx" style="background-color: transparent; padding: 2px; margin: 8px;">Empréstimo</a>&nbsp;
      <a href="FormLivro.aspx" style="background-color: transparent; padding: 2px; margin: 8px;">Livros</a>
            </div>
            <div class="conteudo">
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>&nbsp;
    <asp:TextBox ID="txtCodCliente" runat="server" Width="155px" Height="22px" Enabled="False"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Nome:"></asp:Label>&nbsp;&nbsp;
    <asp:TextBox ID="txtNomeCliente" runat="server" Width="155px" Height="23px" Enabled="False"></asp:TextBox><br />
                <br />
                <br />

                <div class="botoes" align="center" style="padding: 5px; position: relative; float: left">

                    <asp:Button ID="buttonNovoCli" Text="Novo" runat="server" Height="30px" Width="80px" Style="margin-top: 7px; margin-left: 0px; background-color: #b49999;" OnClick="buttonNovoCli_Click" />
                    <asp:Button ID="buttonSalvarCli" Text="Salvar" runat="server" Height="30px"
                        Width="80px"
                        Style="margin-top: 32px; margin-left: 18px; background-color: #b49999;"
                        OnClick="buttonSalvarCli_Click" Enabled="False" />
                    <asp:Button ID="buttonEditarCli" Text="Editar" runat="server" Height="30px"
                        Width="80px"
                        Style="margin-top: 32px; margin-left: 18px; background-color: #b49999;"
                        Enabled="False" OnClick="buttonEditarCli_Click" />
                    <asp:Button ID="buttonExcluirCli" Text="Excluir" runat="server" Height="30px"
                        Width="80px"
                        Style="margin-top: 32px; margin-left: 18px; background-color: #b49999;"
                        Enabled="False" />
                    <br />
                    <br />
                </div>
                <br />
                <br />
                <br />
                <asp:GridView ID="Grid_cliente" runat="server" Font-Italic="True" Font-Names="Calibri" Style="margin-left: 1px; margin-top: 96px" Width="410px" OnSelectedIndexChanged="Grid_cliente_SelectedIndexChanged" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="Smaller" HorizontalAlign="Center" Height="152px">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
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


    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormLivro.aspx.cs" Inherits="Biblioteca.Telas.FormLivro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Biblioteca_Livros</title>
   <link href="../CSS/Biblioteca.css" rel="stylesheet" type="text/css" />
    <!--lincando a página css à atual-->
    <style type="text/css">
        #Menu {
            height: 24px;
        }

        .botoes {
   position: relative;
                  align-items: center;
                  width: 400px;
                  margin-left: 12px;
                  top: -483px;
                  left: 250px;
                  height: 64px;
                  margin-right: 0px;

  
}

        .conteudo {
            background-color: #e0c7c7;
            width: 586px;
            height: 684px;
            margin-left: 170px;
            margin-top: 44px;
            margin-right: 32px;
            align-content: flex-end;
        }

        .txtsLabel {
            align-items: flex-end;
            position: relative;
            top: -6px;
            left: 4px;
            height: 234px;
            width: 554px;
            float: left;
        }
    </style>
</head>
<body>
    <form id="form3" runat="server">
        <div>
            <div id="cabecalho">
                <div id="img">
                    <img src="../Imagens/icone_logo.png" alt="logo da biblioteca aberta" style="height: 109px; width: 113px; margin-top: 4%;" />
                    <h3 style="text-align: center; width: 448px; margin-left: 212px; margin-top: 0px; font-size: 27px; float: left; position: relative; top: -39px; left: 36px; height: 71px; bottom: 2px;">Gerenciador Biblioteca Aberta</h3>
                </div>
                <br />
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

                    <div class="txtsLabel" style="position: relative; width: 509px; height: 142px; top: -29px; right: -49px; bottom: 48px; left: 49px; margin-left: 0px;">
                        &nbsp; 
                 <br />
                        <asp:Label ID="cod_livro" runat="server" Text="Código: " Style="float: left" margin-left="5px"></asp:Label>
                        <asp:TextBox ID="txtCodigoLiv" runat="server" Enabled="False" Style="float: left; margin-left: 14px;" Width="108px"></asp:TextBox>
                        <asp:Label ID="tituloliv" runat="server" Text="Título: " Style="float: left; margin-left: 45px;" margin-left="100px"></asp:Label>
                        <asp:TextBox ID="txtTitulo" runat="server" Style="float: left; margin-left: 10px" Enabled="False" Width="143px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="autor" runat="server" Text="Autor: " Style="float: left; margin-left: 5px"></asp:Label>
                        <asp:TextBox ID="txtAutor" runat="server" Style="float: left; margin-left: 15px;" Enabled="False" Width="108px"></asp:TextBox>
                        <asp:Label ID="editora" runat="server" Text="Editora: " Style="float: left; margin-left: 4px" Width="93px"></asp:Label>
                        <asp:TextBox ID="txtEditora" runat="server" Enabled="False" Style="float: left; margin-left: 0px" Width="141px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="edicao" runat="server" Text="Edição:" Style="float: left"></asp:Label>
                        <asp:TextBox ID="txtEdicao" runat="server" Enabled="False" Style="float: left; margin-left: 14px;" Width="108px"></asp:TextBox>
                                        </div>
                    <br />
                    <br />
                    <asp:GridView ID="Livros_grid" runat="server" margin-top="2%" Height="183px"
                        Style="margin-top: 249px; margin-right: 2px; margin-left: 78px; margin-bottom: 0px;" Width="446px"
                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                        CellPadding="4" Font-Italic="True" Font-Names="Calibri" Font-Size="Medium" OnSelectedIndexChanged="Livros_grid_SelectedIndexChanged1">
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
                <div class="botoes">
                    <asp:Button ID="buttonNovoLiv" Text="Novo" runat="server" Height="30px" Width="80px"
                        Style="margin-top: 20px; margin-left: 0px; background-color: #b49999;"
                        OnClick="buttonNovoLiv_Click" />
                    <asp:Button ID="buttonSalvarLiv" Text="Salvar" runat="server" Height="30px"
                        Width="80px"
                        Style="margin-top: 32px; margin-left: 18px; background-color: #b49999;"
                        Enabled="False" OnClick="buttonSalvarLiv_Click" />
                    <asp:Button ID="buttonEditarLiv" Text="Editar" runat="server" Height="30px"
                        Width="80px"
                        Style="margin-top: 32px; margin-left: 18px; background-color: #b49999;"
                        Enabled="False" OnClick="buttonEditarLiv_Click" />
                    <asp:Button ID="buttonExcluirLiv" Text="Excluir" runat="server" Height="30px"
                        Width="80px"
                        Style="margin-top: 32px; margin-left: 18px; background-color: #b49999;"
                        Enabled="False" OnClick="buttonExcluirLiv_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

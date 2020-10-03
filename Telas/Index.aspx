<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Biblioteca.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Biblioteca</title>
   <link href="../CSS/Biblioteca.css" rel="stylesheet" type="text/css" /><!--lincando a página css à atual-->       
    <style type="text/css">
        .Menu {
            margin-left: 207px;
            margin-bottom: 0px;
        }
        #Menu {
            margin-left: 5px;
            margin-top: 0px;
        }
    </style>
   
       
</head>
<body > <!-- DÚVIDA: precisa colocar este estilo no css?-->
    <form id="form1" runat="server">
        <div id="cabecalho">
           
           <div id="img">
              
               <img src="../Imagens/icone_logo.png" alt="logo da biblioteca aberta" style="height: 109px; width: 113px; margin-top:4%"/>
                <h3 style="text-align: center; width: 523px; margin-left: 212px; font-size: 27px; position: relative; float: left; top: -50px; left: 0px; height: 36px;" 
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
           <br /><br /><br /><br />
            <h2 style="text-align: center">Viajar pela leitura</h2>
            <p style="text-align:center">
                " Viajar pela leitura<br />
                  sem rumo, sem intenção.<br />
                  Só para viver a aventura<br />
                  que é ter um livro nas mãos.<br />
                  É uma pena que só saiba disso<br />
                  quem gosta de ler.<br />
                  Experimente!<br />
                  Assim sem compromisso,<br />
                  você vai me entender.<br />
                  Mergulhe de cabeça<br />
                  na imaginação! "<br />
            </p>
            <p style="text-indent: 100px">- Clarice Pacheco</p>
            </div>
    </form>
    </body>
</html>

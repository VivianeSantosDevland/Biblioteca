using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca.Negócio;
using Biblioteca.Dados;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Biblioteca.Telas
{
    public partial class FormLivro : System.Web.UI.Page
    {

        public string Conn = ConfigurationManager.AppSettings["Banco_Biblioteca"];
        MySqlConnection conexao;
        MySqlDataAdapter da;
        LivroBD livBD = new LivroBD();
        ClassLivro classLiv = new ClassLivro();
        //int opcao;
        protected void Page_Load(object sender, EventArgs e)
        {
            PreencherGridViewLiv();
           
        }

        protected void buttonNovoLiv_Click(object sender, EventArgs e)
        {
            buttonSalvarLiv.Enabled = true;
            LimparCampos();

            txtTitulo.Enabled = true;
            txtAutor.Enabled = true;
            txtEditora.Enabled = true;
            txtEdicao.Enabled = true;
        }



        public void LimparCampos()
        {
            txtAutor.Text = null;
            txtCodigoLiv.Text = null;
            txtTitulo.Text = null;
            txtEditora.Text = null;
            txtEdicao.Text = null;

        }

        protected void buttonSalvarLiv_Click(object sender, EventArgs e)
        {
            
            if (txtCodigoLiv.Text == null)
            {
                classLiv.titulo = txtTitulo.Text;
                classLiv.autor = txtAutor.Text;
                classLiv.edicao = txtEdicao.Text;
                classLiv.editora = txtEditora.Text;
                livBD.CadastrarLivro(classLiv);
              
                LimparCampos();
                DesabilitarCampos();
                //Bloqueio do botão
                buttonSalvarLiv.Enabled = false;
                PreencherGridViewLiv();
          
            } if (txtCodigoLiv.Text != null)
            {
               
                classLiv = new ClassLivro();
                classLiv.titulo = txtTitulo.Text;
                classLiv.autor = txtAutor.Text;
                classLiv.edicao = txtEdicao.Text;
                classLiv.editora = txtEditora.Text;
                classLiv.cod_liv = txtCodigoLiv.Text;
               int re =  livBD.AlterarLivro(classLiv);
                if (re > 0)
                {
                  
                    PreencherGridViewLiv();
                    LimparCampos();
                    DesabilitarCampos();
                    //Bloqueio do botão
                    buttonSalvarLiv.Enabled = false;
                }
             
            }
      
        }

        // Desabilitar campos
        public void DesabilitarCampos()
        {
            txtTitulo.Enabled = false;
            txtAutor.Enabled = false;
            txtEditora.Enabled = false;
            txtEdicao.Enabled = false;
        }


        public void PreencherGridViewLiv()
        {
            conexao = new MySqlConnection(Conn);
            string sql = "select *from livro";
            conexao.Open();
            da = new MySqlDataAdapter(sql, conexao);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Livros_grid.DataSource = dt;
                Livros_grid.DataBind();
              
            }

            conexao.Close();
        }
        protected void buttonEditarLiv_Click(object sender, EventArgs e)
        {

           
            
            buttonSalvarLiv.Enabled = true;
            txtAutor.Enabled = true;
            txtEdicao.Enabled = true;
            txtEditora.Enabled = true;
            txtTitulo.Enabled = true;
            
        }

        protected void Livros_grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Livros_grid_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
            //botões
            buttonEditarLiv.Enabled = true;
            buttonExcluirLiv.Enabled = true;
            //Campo
            txtAutor.Enabled = false;
            txtCodigoLiv.Enabled = false;
            txtEdicao.Enabled = false;
            txtEditora.Enabled = false;
            txtTitulo.Enabled = false;
            //linha selecionada
            GridViewRow gr = Livros_grid.SelectedRow;
            txtCodigoLiv.Text = HttpUtility.HtmlDecode(gr.Cells[1].Text);
            txtTitulo.Text = HttpUtility.HtmlDecode(gr.Cells[2].Text);
            txtAutor.Text = HttpUtility.HtmlDecode(gr.Cells[3].Text);
            txtEdicao.Text = HttpUtility.HtmlDecode(gr.Cells[4].Text);
            txtEditora.Text = HttpUtility.HtmlDecode(gr.Cells[5].Text);
           
         }

        protected void buttonExcluirLiv_Click(object sender, EventArgs e)
        {
            classLiv.cod_liv = txtCodigoLiv.Text;
           int x = livBD.ExcluirLivro(classLiv);
           if (x > 0)
            {
               
               
                LimparCampos();
                PreencherGridViewLiv();
                buttonEditarLiv.Enabled = false;
                buttonExcluirLiv.Enabled = false;
            }
            
        }
    }
}
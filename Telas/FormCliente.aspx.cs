using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca.Dados;
using Biblioteca.Negócio;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Common;

namespace Biblioteca
{


    public partial class FormCliente : System.Web.UI.Page
    {
        public string Conn = ConfigurationManager.AppSettings["Banco_Biblioteca"];
        MySqlConnection conexao;       
        MySqlDataAdapter da;
        string opcaoSalvar;
        bool opSal;
        string opcaoAltera;
        bool opAlt;
        string c;
        ClienteBD cliBD = new ClienteBD();
        ClassCliente classcli;

        protected void Page_Load(object sender, EventArgs e)
        {
             opcaoSalvar = "salvar";
            opSal = true;
             opcaoAltera = null;
            opAlt = false;
            PreencherGridViewClie();
        }

        protected void buttonNovoCli_Click(object sender, EventArgs e)
        {
           
            txtNomeCliente.Enabled = true;
            buttonSalvarCli.Enabled = true;
            LimparCampos();
           
            Grid_cliente.Enabled = false;
            opcaoSalvar = "salvar";
            opSal = true;
            opcaoAltera = null;
            opAlt = false;

         
        }

        public void LimparCampos()
        {
            txtCodCliente.Text = null;
            txtNomeCliente.Text = null;
        }

        protected void buttonSalvarCli_Click(object sender, EventArgs e)
        {
            if ((opcaoSalvar.Equals("salvar") == true) && (opSal == true))
            {
                classcli = new ClassCliente();
                classcli.NomeClie = txtNomeCliente.Text;
                int r = cliBD.CadastrarCliente(classcli);
                if (r > 0)
                {

                    PreencherGridViewClie();
                    LimparCampos();
                    buttonSalvarCli.Enabled = false;
                    txtNomeCliente.Enabled = false;
                }
            }
                 }

        public void PreencherGridViewClie()
        {
            conexao = new MySqlConnection(Conn);
            string sql = "select *from cliente";
           
            conexao.Open();
            da = new MySqlDataAdapter(sql, conexao);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                Grid_cliente.DataSource = dt;
                Grid_cliente.DataBind();
                Grid_cliente.Columns[0].ItemStyle.Width = 50;
                            }
            
            conexao.Close();
        }
        

        /*public void configurarGrid()
        {
            try
            {
               // Grid_cliente.Columns[0].HeaderText = "Seleção";
                Grid_cliente.Columns[0].HeaderText = "Código";
                Grid_cliente.Columns[1].HeaderText = "Nome";

                          }
            catch(Exception err)
            {
                throw err;
            }
       
        }*/

        protected void Grid_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //botões
            buttonEditarCli.Enabled = true;
            buttonExcluirCli.Enabled = true;
            //Campo
            txtNomeCliente.Enabled = false;
            //linha selecionada
            GridViewRow gr = Grid_cliente.SelectedRow;
            txtCodCliente.Text = HttpUtility.HtmlDecode(gr.Cells[1].Text);
            txtNomeCliente.Text = HttpUtility.HtmlDecode(gr.Cells[2].Text);
        }

        protected void buttonEditarCli_Click(object sender, EventArgs e)
        {
            opcaoSalvar = null;
            opcaoAltera = "alterar";
            c = txtCodCliente.Text;
            //botão
            buttonSalvarCli.Enabled = true;
            txtNomeCliente.Enabled = true;
        }

        protected void buttonExcluirCli_Click(object sender, EventArgs e)
        {
            classcli = new ClassCliente();
            classcli.CodClie = txtCodCliente.Text;
            cliBD.ExcluirCliente(classcli);
          
            LimparCampos();
            PreencherGridViewClie();
            buttonExcluirCli.Enabled = false;
            buttonEditarCli.Enabled = false;
        }
    }
}
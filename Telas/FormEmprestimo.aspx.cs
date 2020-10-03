using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca.Negócio;
using Biblioteca.Dados;
namespace Biblioteca.Telas
{
    public partial class FormEmprestimo : System.Web.UI.Page
    {
        public string Conn = ConfigurationManager.AppSettings["Banco_Biblioteca"];
        public MySqlDataAdapter da;
        MySqlCommand comando;
        public string sql;
        MySqlConnection conexao;
        int c, cl;
       // string opE, opS;
      //  string item, iteml;

        ClassEmprestimo emprestimo = new ClassEmprestimo();
        EmprestimoBD empBD = new EmprestimoBD();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtData.Text = jcalendarEmp.SelectedDate.ToString("dd/MM/yyyy");
            if (!IsPostBack)
            {
                preencherDropdowListCliente();
                PreencherDropdowListLivro();
            }
            PreencherGridViewEmp();
        }


        public void preencherDropdowListCliente()
        {
                    
                sql = "select CodigoCliente, Nome from cliente";
                //comando = new MySqlCommand(sql, conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, Conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    listCliente.DataSource = dt;
                    listCliente.DataTextField = "Nome";
                    listCliente.DataValueField = "CodigoCliente";
                    listCliente.DataBind();
                
            }

        }
        
        public void PreencherDropdowListLivro()
        {
                sql = "select CodigoLivro, Titulo from livro";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, Conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    listLivro.DataSource = dt;
                    listLivro.DataTextField = "Titulo";
                    listLivro.DataValueField = "CodigoLivro";
                    listLivro.DataBind();

                  }
        }



        public void LimparCampos()
        {
            txtCodigoEmp.Text = null;
            jcalendarEmp.SelectedDate = DateTime.Now;
            DateTime dat = DateTime.Now;
            txtData.Text = dat.ToString("dd/MM/yyyy");
            jcalendarEmp.SelectedDate = dat;
            listCliente.SelectedIndex = 0;
            listLivro.SelectedIndex = 0;
            
        }

        protected void buttonNovoEmp_Click(object sender, EventArgs e)
        {
            listCliente.Enabled = true;
            listLivro.Enabled = true;
            jcalendarEmp.Enabled = true;
            ImageButton_Jcalendar.Enabled = true;
            
            LimparCampos();
            //Botões
            butonSalvarEmp.Enabled = true;
        }


        //Pegar código cliente
        public void CodC(string item)
        {
            MySqlDataReader reader;
            sql = "select *from Cliente where Nome = ?pNome";
            comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("pNome", item);
            try
            {
                conexao.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    c = reader.GetInt32("CodigoCliente");
                    
                }
            }
            catch (Exception err)
            {
                throw err;

            }
            
                reader.Close();
            conexao.Close();
        }

        //Pegar código livro
        public void CodL(string iteml)
        {
            MySqlDataReader readerl;
            sql = "select *from livro where Titulo = ?pTitulo";
            comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("pTitulo", iteml);
            try
            {
                conexao.Open();
                readerl = comando.ExecuteReader();
                if (readerl.HasRows)
                {
                    readerl.Read();
                    cl = readerl.GetInt32("CodigoLivro");
                   
                }
            }
            catch (Exception err)
            {
                throw err;

            }
            readerl.Close();
            conexao.Close();
        }


        protected void butonSalvarEmp_Click(object sender, EventArgs e)
        {
            CodC(listCliente.SelectedItem.Text);
            emprestimo.codCliente = Convert.ToInt32(c);
            CodL(listLivro.SelectedItem.Text);
            emprestimo.codLivro = Convert.ToInt32(cl);
            string data = Convert.ToDateTime(txtData.Text).ToString("yyyy/MM/dd");
            emprestimo.dataEmprestimo = Convert.ToDateTime(data);
            empBD.CadastrarEmprestimo(emprestimo);
           
            listCliente.Enabled = false;
            listLivro.Enabled = false;
            jcalendarEmp.Enabled = false;
            ImageButton_Jcalendar.Enabled = false;
            butonSalvarEmp.Enabled = false;
            PreencherGridViewEmp();
            preencherDropdowListCliente();
            PreencherDropdowListLivro();
            LimparCampos();
        }

        protected void buttonExclui_Click(object sender, EventArgs e)
        {
            emprestimo.codEmpre = txtCodigoEmp.Text;
            int x = empBD.ExcluirEmprestimo(emprestimo);
            if (x > 0)
            {

                
                LimparCampos();
                PreencherGridViewEmp();
                buttonEditar.Enabled = false;
                buttonExclui.Enabled = false;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void jcalendarEmp_SelectionChanged(object sender, EventArgs e)
        {
            txtData.Text = jcalendarEmp.SelectedDate.ToString("dd/MM/yyyy");
            jcalendarEmp.Visible = false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //não funciona como quero
            
            if (jcalendarEmp.Visible == false)
            {
                jcalendarEmp.Visible = true;
                jcalendarEmp.Enabled = true;
               
            }
            else if(jcalendarEmp.Visible == true)
                {
                jcalendarEmp.Visible = false;
                jcalendarEmp.Enabled = false;
            }
        }

        protected void buttonEditar_Click(object sender, EventArgs e)
        {
            jcalendarEmp.Enabled = true;
            listCliente.Enabled = true;
            listLivro.Enabled = true;
            ImageButton_Jcalendar.Enabled = true;
            
        }
        public void PreencherGridViewEmp()
        {
            conexao = new MySqlConnection(Conn);
             sql = "select CodigoEmprest, DataEmprest, Nome, Titulo from emprestimo, cliente "
               + " join livro where CodigoCliente = CodigoCli and CodigoLiv= CodigoLivro";
            conexao.Open();
            da = new MySqlDataAdapter(sql, conexao);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                emprestimoGrid.DataSource = dt;
                emprestimoGrid.DataBind();
            }

            conexao.Close();
        }

        protected void listCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void emprestimoGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            //botões
            buttonEditar.Enabled = true;
            buttonExclui.Enabled = true;
       
            //linha selecionada
            GridViewRow gr = emprestimoGrid.SelectedRow;
            txtCodigoEmp.Text = HttpUtility.HtmlDecode(gr.Cells[1].Text);
            string d = Convert.ToDateTime(HttpUtility.HtmlDecode(gr.Cells[2].Text)).ToString("dd/MM/yyyy");
            txtData.Text = d;
            //Selecionar nome de cliente no Dropdownlist listCliente
            string nome = HttpUtility.HtmlDecode(gr.Cells[3].Text);
            foreach (ListItem item in listCliente.Items)
            {
                if (item.Text == nome)
                {
                    listCliente.ClearSelection();
                    listCliente.Items.FindByText(nome).Selected = true;                                   
                }
            }
           //Selecionar título do livro no Dropdownlist listLivro
            string livro = HttpUtility.HtmlDecode(gr.Cells[4].Text);
            foreach(ListItem iteml in listLivro.Items)
            {
                if(iteml.Text == livro)
                {
                    listLivro.ClearSelection();
                    listLivro.Items.FindByText(livro).Selected = true;
                }
            }


        }
    }
}
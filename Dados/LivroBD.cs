using System;
using System.Configuration;
using Biblioteca.Negócio;
using MySql.Data.MySqlClient;

namespace Biblioteca.Dados
{
    public class LivroBD
    {
        public static MySqlConnection conexao;
        public static MySqlCommand comando;
        public MySqlDataAdapter da;
        public string sql;
        public string conn;

        //Construtor
        public LivroBD()
        {
            conn = ConfigurationManager.AppSettings["Banco_Biblioteca"];
        }
        public void CadastrarLivro(ClassLivro livro)
        {
            conexao = new MySqlConnection(conn);
            sql = "insert into livro(Titulo, Autor, Edicao, Editora) values (?pTitulo, ?pAutor, ?pEdicao, ?pEditora)";

            comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("pTitulo", livro.titulo);
            comando.Parameters.AddWithValue("pAutor", livro.autor);
            comando.Parameters.AddWithValue("pEdicao", livro.edicao);
            comando.Parameters.AddWithValue("pEditora", livro.editora);


            try
            {
                conexao.Open();
                int result = comando.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                conexao.Close();
            }

        }

        public int AlterarLivro(ClassLivro livro)
        {
            int result;
            conexao = new MySqlConnection(conn);
            sql = "update livro set Titulo = ?pTitulo, Autor =?pAutor, Edicao = ?pEdicao, Editora = ?pEditora where CodigoLivro = ?pCodigoLivro";
            comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("pTitulo", livro.titulo);
           comando.Parameters.AddWithValue("pAutor", livro.autor);
            comando.Parameters.AddWithValue("pEdicao", livro.edicao);
            comando.Parameters.AddWithValue("pEditora", livro.editora);
            comando.Parameters.AddWithValue("pCodigoLivro", livro.cod_liv);
            try
            {
                conexao.Open();
                result = comando.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                conexao.Close();
            }
            return result;

        }

        public int ExcluirLivro(ClassLivro livro)
        {
            int result;
            conexao = new MySqlConnection(conn);
            sql = "delete from livro where CodigoLivro = ?pCodigoLivro";
            comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("pCodigoLivro", livro.cod_liv);
            try
            {
                conexao.Open();
                result = comando.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                conexao.Close();
            }
            return result;
        }
    }
}
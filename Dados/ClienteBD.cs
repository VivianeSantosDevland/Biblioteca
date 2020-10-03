using System;
using System.Configuration;
using Biblioteca.Negócio;
using MySql.Data.MySqlClient;
using System.Data;

namespace Biblioteca.Dados
{
    public class ClienteBD
    {
        public static MySqlConnection conexao;

        public static MySqlCommand comando;
        public MySqlDataAdapter da;
        public string sql;
        public string conn;

        //Construtor
        public ClienteBD()
        {
            conn = ConfigurationManager.AppSettings["Banco_Biblioteca"];
        }


        //Método para inserir dados no banco

        public int CadastrarCliente(ClassCliente clienteS)
        {
            int result;
            conexao = new MySqlConnection(conn);
            sql = "insert into cliente(Nome) values (?pNome)";
            comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("pNome", clienteS.NomeClie);
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

        //Método para alterar os dados

        public int AlterarCliente(ClassCliente clienteA)
        {
            int resultado;
            conexao = new MySqlConnection(conn);
            sql = "update cliente set Nome = ?pNome where CodigoCliente = ?pCodigoCliente";
            comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("pNome", clienteA.NomeClie);
            comando.Parameters.AddWithValue("pCodigoCliente", clienteA.CodClie);
            try
            {
                conexao.Open();
                resultado = comando.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                conexao.Close();
            }
            return resultado;

        }

        public void ExcluirCliente(ClassCliente cliente)
            {
            conexao = new MySqlConnection(conn);
            sql = "delete from cliente where CodigoCliente = ?pCodigoCliente";
            comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("pCodigoCliente", cliente.CodClie);
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

    }
}
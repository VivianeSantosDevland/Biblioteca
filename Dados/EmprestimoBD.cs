using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Biblioteca
{

    public class EmprestimoBD
        {
            public static MySqlConnection conexao;
            public static MySqlCommand comando;
            public MySqlDataAdapter da;
            public string sql;
            public string conn;

            public int codCli;
            public int codLiv;

            //Construtor
            public EmprestimoBD()
            {
                conn = ConfigurationManager.AppSettings["Banco_Biblioteca"];
            }

            public void CadastrarEmprestimo(ClassEmprestimo emprestimo)
            {
                conexao = new MySqlConnection(conn);
                sql = "insert into emprestimo(DataEmprest, CodigoCli, CodigoLiv ) values (?pDataEmprest, ?pCodigoCli, ?pCodigoLiv)";
                comando = new MySqlCommand(sql, conexao);

                comando.Parameters.AddWithValue("pDataEmprest", emprestimo.dataEmprestimo);
                comando.Parameters.AddWithValue("pCodigoCli", emprestimo.codCliente);
                comando.Parameters.AddWithValue("pCodigoLiv", emprestimo.codLivro);

                try
            {
                 conexao.Open();
                 int result = comando.ExecuteNonQuery();

            }catch(Exception err)
            {
                throw err;
            }

            finally
            {
                conexao.Close();
            }
            }



        public int ExcluirEmprestimo(ClassEmprestimo emprestimo)
        {
            int result;
            conexao = new MySqlConnection(conn);
            sql = "delete from emprestimo where CodigoEmprest = ?pCodigoEmprest";
            comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("pCodigoEmprest", emprestimo.codEmpre);
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
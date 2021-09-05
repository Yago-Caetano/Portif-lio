using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Portifolio_backend.DAO
{
    public static class HelperDAO
    {
        public static DataTable ExecutaProcSelect(string nomeProc, MySqlParameter[] parametros)
        {
            using (MySqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(nomeProc, conexao))
                {

                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    conexao.Close();
                    return tabela;
                }
            }
        }
        public static object ExecuteFunction(string Nome, MySqlParameter p)
        {

            MySqlConnection con = ConexaoBD.GetConexao();

            MySqlCommand com = new MySqlCommand("SELECT dbo." + Nome + "(" + p.Value + ")", con);
            return com.ExecuteScalar();
        }
        public static DataTable ExecutaProcSelect(string nomeProc, MySqlParameter[] parametros, MySqlConnection conexao)
        {

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(nomeProc, conexao))
            {

                if (parametros != null)
                    adapter.SelectCommand.Parameters.AddRange(parametros);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                conexao.Close();
                return tabela;
            }

        }
        public static int ExecutaProc(string nomeProc, MySqlParameter[] parametros, bool consultaUltimoIdentity = false)
        {
            int retValue = 0;
            using (MySqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (MySqlCommand comando = new MySqlCommand(nomeProc, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();

                    if (consultaUltimoIdentity)
                    {
                        var data = ExecutaProcSelect("spGetIdentity", null, conexao);
                        retValue = Convert.ToInt32(data.Rows[0]["id"]);
                    }
                }
                conexao.Close();
                return retValue;
            }
        }

    }
}

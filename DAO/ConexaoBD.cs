using MySqlConnector;
using System;

namespace Portifolio_backend.DAO
{
    public class ConexaoBD
    {
        public static MySqlConnection GetConexao()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3306;
            conn_string.UserID = "root" ;// "user"
            conn_string.Password = "root" ;// "123456" "123456"
            //conn_string.Password =  "123456"; 
            conn_string.Database = "PocAtembiciV1";

            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            MyCon.Open();
            return MyCon;
        }
    }
}

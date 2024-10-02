using MySql.Data.MySqlClient;

namespace API_USUARIOS.Dao
{
    public class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            return new MySqlConnection("Server=localhost;Database=bdcontrolevendas;Uid=root;Pwd=root;");
        }
    }
}

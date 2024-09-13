using System;
using System.Data.SqlClient;

namespace TecnicalTestCodifico.DbConnection
{
    public class BDConnection
    {

        private readonly string _connectionString;

        // Constructor que recibe la cadena de conexión
        public BDConnection()
        {
            // Cadena de conexión con autenticación de Windows
            _connectionString = "Server=localhost;Database=StoreSample;Integrated Security=True;";
        }

        // Método que devuelve la conexión a la base de datos
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // Método para abrir la conexión
        public void OpenConnection(SqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Método para cerrar la conexión
        public void CloseConnection(SqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}

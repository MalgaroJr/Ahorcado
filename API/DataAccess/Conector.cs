using Microsoft.Data.SqlClient;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

namespace API.DataAccess
{
    public class Conector
    {
        protected string sqlstr;

        protected SqlConnection conn;

        public Conector()
        {
            var config=GetConfiguration();
            sqlstr = config;
            //sqlstr = "";
        }

        protected string GetConfiguration()
        {

            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                }
            };
            var client = new SecretClient(new Uri("https://hangedvault.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret("Hanged--conn");

            string secretValue = secret.Value;
            return secretValue;
        }

        protected void Inicializar()
        {
            conn = new SqlConnection(sqlstr);
            try
            {
                conn.Open();
            }
            catch (SqlException e)
            {
                throw new Exception("No se establecio conexion con la base de datos: "+e.Message);
            }
        }

        protected void Cerrar() //cierra conexion
        {
            try
            {
                conn.Close();
            }
            catch (SqlException e)
            {
                throw new Exception("Alerta: no se cerro la conexion: "+e.Message);
            }
        }

        protected SqlDataReader ExecuteReader(String commandText) //Ejecuta sentencias SQL
        {
            SqlCommand comando = new SqlCommand(commandText, conn);
            SqlDataReader reader = comando.ExecuteReader();
            return reader;
        }
    }
}

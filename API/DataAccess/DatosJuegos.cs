using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using ClasesAhorcado;

namespace API.DataAccess
{
    public class DatosJuegos: Conector
    {
        public List<Juego> All(string username)
        {
            List<Juego> juegos = new List<Juego>();
            try
            {
                string s = "SELECT TOP (100) [Id],[Palabra], [letrasusadas], [Jugador] FROM [dbo].[Juego] WHERE [Jugador]=@jugador";
                Inicializar();
                SqlCommand cmd= new SqlCommand(s, conn);
                cmd.Parameters.AddWithValue("@jugador", username);
                SqlDataReader rdr=cmd.ExecuteReader();
                while (rdr.Read()) 
                {
                    Juego j = new Juego(rdr.GetString(1));
                    var lu = rdr.GetString(2);
                    foreach(char c in lu)
                    {
                        j.verificar(c);
                    }
                    juegos.Add(j);
                }
                rdr.Close();
                Cerrar();
            }
            catch (Exception e)
            {

                throw new Exception($"Error al recuperar los huegos de {username}" + e.Message);
            }
            return juegos;
        }

        public void Nuevo(Juego j, string username)
        {
            int n=0;
            SqlTransaction tran;
            Inicializar();
            tran=conn.BeginTransaction();
            try
            {
                string s = "INSERT INTO [dbo].[Juego]([Palabra],[letrasusadas],[Jugador]) VALUES (@palabra, @letrasu, @jugador)";
                
                SqlCommand sql = new SqlCommand(s, conn);
                sql.Transaction = tran;
                sql.Parameters.AddWithValue("@palabra", j.Palabra);
                sql.Parameters.AddWithValue("@letrasu", j.letrasUsadas);
                sql.Parameters.AddWithValue("@jugador",username);
                n= sql.ExecuteNonQuery();
                tran.Commit();
                Cerrar();
            }
            catch (Exception)
            {
                try
                {
                    tran.Rollback();
                    Cerrar();
                }
                catch (Exception ex)
                {
                    throw new Exception("No fue posible registrar el juego " + ex.Message);
                }
                
                throw;
            }
            if (n == 0)
            {
                throw new Exception("No fue posible registrar el juego");
            }
        }
    }
}

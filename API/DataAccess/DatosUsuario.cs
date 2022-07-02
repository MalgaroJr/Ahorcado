using ClasesAhorcado;
using Microsoft.Data.SqlClient;

namespace API.DataAccess
{
    public class DatosUsuario : Conector
    {
        public DatosUsuario() :base() {}
        
        public List<Usuario> All()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                Inicializar();

                SqlDataReader rdr = ExecuteReader("SELECT TOP (1000) [id], [username], [password], [nombre]," +
                    "[fecha_creacion] FROM [dbo].[Usuarios]");
                while (rdr.Read())
                {
                    Usuario usuario = new Usuario(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetDateTime(4));
                    lista.Add(usuario);
                }
                Cerrar();
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar usuarios: "+e.Message);
            }
            return lista;
        }

        public Usuario get(string username)
        {
            Usuario usuario = null;
            try
            {
                Inicializar();
                string s = $"SELECT TOP (1) [id], [username], [password], [nombre]," +
                    "[fecha_creacion], [fecha_eliminacion] FROM [dbo].[Usuarios] WHERE [username]=@usrname";
                SqlCommand cmd = new SqlCommand(s, conn);
                cmd.Parameters.Add("@usrname", System.Data.SqlDbType.VarChar, 50).Value=username;
                SqlDataReader rdr=cmd.ExecuteReader();
                if (rdr.Read())
                {
                    usuario= new Usuario(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetDateTime(4));
                }
                else
                {
                    Cerrar();
                    throw new Exception("No existe ese nombre de usuario");
                }
                Cerrar();
            }
            catch(Exception e)
            {
                throw new Exception("Error al recuperar el usuario: " + e.Message);
            }
            return usuario;
        }

        public void Registrar(Usuario u)
        {
            try
            {
                Inicializar();
                SqlCommand cmd = new SqlCommand("INSERT INTO[dbo].[Usuarios] ([nombre] ,[username] ,[password],"+
                "[fecha_creacion]) VALUES (@nombre, @username, @password, @fecha_creacion)", conn);
                cmd.Parameters.AddWithValue("@username", u.Username);
                cmd.Parameters.AddWithValue("@nombre", u.Name);
                cmd.Parameters.AddWithValue("@password", u.Password);
                cmd.Parameters.AddWithValue("@fecha_creacion", DateTime.Now);
                int n=cmd.ExecuteNonQuery();
                Cerrar();
                if (n == 0)
                {
                    throw new Exception("No se modifico ningun registro");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al registrar el usuario: " + e.Message);
            }
        }

    }
}

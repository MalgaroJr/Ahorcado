using ClasesAhorcado;
using UI.Repository.IServices;
using ClasesAhorcado;
using System.Linq;
using System.Collections;

namespace UI.Repository
{
    public class UserHardcodedService : IUserService
    {
        public UserHardcodedService() { }

        public static List<Usuario> Usuarios { get; private set; }= new List<Usuario>();

        public async Task<Usuario> GetUsuarioByUsername(string username)
        {
            var usuario = from Usuario us in Usuarios where us.Username == username select us;
            Usuario u = await Task.Run(() => { return usuario.FirstOrDefault(); });
            //await Task.Delay(10);
            return u;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var usuarios = from Usuario us in Usuarios select us;
            var users = usuarios.ToList();
            await Task.Delay(10);
            return users;
        }

        public async Task New(Usuario u)
        {
            u.fechaCreacion = DateTime.Now;
            u.Juegos = new List<Juego>();
            Usuarios.Add(u);
        }
    }
}

using ClasesAhorcado;
using UI.Repository.IServices;

namespace UI.Repository
{
    public class JuegoHardcodedService : IJuegoService
    {
        public async Task<IEnumerable<Juego>> GetAllJuegosAsync(string username)
        {
            var usuario = from Usuario us in UserHardcodedService.Usuarios where us.Username == username select us;
            Usuario u= usuario.FirstOrDefault();
            List<Juego> list = u.Juegos;
            return list;
        }

        public Task<Juego> GetJuegoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Juego>> GetJuegosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RegistrarJuego(Usuario u)
        {
            foreach(Usuario usuario in UserHardcodedService.Usuarios)
            {
                if (usuario.Username == u.Username)
                {
                    usuario.Juegos.Add(u.Juegos.Last());
                    break;
                }
            }
            await Task.Delay(10);
            return;
        }
    }
}

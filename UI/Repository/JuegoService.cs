using ClasesAhorcado;
using UI.Repository.IServices;

namespace UI.Repository
{
    public class JuegoService : IJuegoService
    {
        public Task<IEnumerable<Juego>> GetAllJuegosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Juego> GetJuegoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Juego>> GetJuegosAsync()
        {
            throw new NotImplementedException();
        }

        public Task RegistrarJuego(Juego juego)
        {
            throw new NotImplementedException();
        }
    }
}

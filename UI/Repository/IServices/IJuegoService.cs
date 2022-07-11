using ClasesAhorcado;

namespace UI.Repository.IServices
{
    public interface IJuegoService
    {
        Task<IEnumerable<Juego>> GetJuegosAsync();

        Task<IEnumerable<Juego>> GetAllJuegosAsync(string username);

        Task<Juego> GetJuegoByIdAsync(int id);

        Task RegistrarJuego(Usuario u);
    }
}

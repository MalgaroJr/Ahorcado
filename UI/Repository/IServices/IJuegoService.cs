using ClasesAhorcado;

namespace UI.Repository.IServices
{
    public interface IJuegoService
    {
        Task<IEnumerable<Juego>> GetJuegosAsync();

        Task<IEnumerable<Juego>> GetAllJuegosAsync();

        Task<Juego> GetJuegoByIdAsync(int id);

        Task RegistrarJuego(Juego juego);
    }
}

using Microsoft.AspNetCore.Components;
using UI.Repository.IServices;
using ClasesAhorcado;

namespace UI.Pages
{
    public class INBase: ComponentBase
    {
        [Inject]
        public IJuegoService JuegoService { get; set; }
        protected string msg = "";
        public async Task RegistrarJuego(Usuario us)
        {
            try
            {
                await JuegoService.RegistrarJuego(us);
            }
            catch (Exception e)
            {
                msg= e.Message;
            }
        }

        public async Task<List<Juego>> RecuperarJuegos(string username)
        {
            List<Juego> juegos = new List<Juego>();
            try
            {
                var js = await JuegoService.GetAllJuegosAsync(username);
                juegos.AddRange(js);
            }
            catch (Exception e)
            {
                msg = "No es posible mostrar las estadisticas en este momento:"+e.Message;
                return null;
            }
            return juegos;
        }
    }
}

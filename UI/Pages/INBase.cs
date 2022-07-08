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
    }
}

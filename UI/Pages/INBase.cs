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
        protected int total;
        protected int[] cantv;
        protected int[] ratio;

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

        public INBase():base()
        {
            total = 1;
            cantv = new int[] { 1, 0, 0, 0, 0, 0, 0, 0 };
            ratio = new int[] { 0, 1 };
        }
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            total = 1;
            cantv = new int[] { 1, 0, 0, 0, 0, 0, 0, 0 };
            ratio = new int[] { 0, 1 };
        }

    }
}

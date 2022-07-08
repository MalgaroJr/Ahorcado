using ClasesAhorcado;
using UI.Repository.IServices;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace UI.Repository
{
    public class JuegoService : IJuegoService
    {
        public JuegoService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        public async Task<IEnumerable<Juego>> GetAllJuegosAsync(string username)
        {
            Juego[] juegos = null;
            try
            {
                string url = this.HttpClient.BaseAddress.ToString() + $"api/Juegos/{username}";
                var response = await this.HttpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode== System.Net.HttpStatusCode.NoContent)
                    {
                        throw new ArgumentNullException("No se recuperaron los juegos");
                    }
                    var results= response.Content.ReadAsStringAsync().Result;
                    juegos=JsonConvert.DeserializeObject<Juego[]>(results);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    string errormsg = JsonConvert.DeserializeObject<string>(result);
                    throw new Exception(errormsg);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return juegos;
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
            string json=JsonConvert.SerializeObject(u);
            string url = this.HttpClient.BaseAddress.ToString() + "api/Juegos";
            var response=await this.HttpClient.PostAsJsonAsync<string>(url, json);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                string errormsg = JsonConvert.DeserializeObject<string>(result);
                throw new Exception(errormsg);
            }
        }
    }
}

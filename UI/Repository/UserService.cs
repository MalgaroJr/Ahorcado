using ClasesAhorcado;
using UI.Repository.IServices;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace UI.Repository
{
    public class UserService : IUserService
    {
        public UserService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        public async Task<Usuario> GetUsuarioByUsername(string username)
        {
            Usuario u;
            try
            {
                var usuario = await this.HttpClient.GetStringAsync($"api/Users/{username}");
                if(usuario == null)
                {
                    throw new ArgumentNullException("username");
                }
                u = JsonConvert.DeserializeObject<Usuario>(usuario);
            }
            catch (ArgumentNullException e)
            {
                throw;
            }
            return u;
        }

        public Task<IEnumerable<Usuario>> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public async Task New(Usuario u)
        {
            string json = JsonConvert.SerializeObject(u);
            //StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            //var response= await this.HttpClient.PostAsync("api/Users", httpContent);
            var response = await this.HttpClient.PostAsJsonAsync<string>("api/Users", json);
            if (!response.StatusCode.Equals(200))
            {
                throw new Exception();
            }
        }
    }
}

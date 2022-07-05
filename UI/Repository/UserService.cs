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
            //HttpClient.DefaultRequestHeaders.Add("Hanged-Site", "C# Program");
            //HttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient HttpClient { get; }

        public async Task<Usuario> GetUsuarioByUsername(string username)
        {
            Usuario u=null;
            try
            {
                var response = await this.HttpClient.GetAsync($"https://localhost:7092/api/Users/{username}");
                if(response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        throw new ArgumentNullException("username");
                    }
                    var usuario=response.Content.ReadAsStringAsync().Result;
                    u = JsonConvert.DeserializeObject<Usuario>(usuario);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
            await this.HttpClient.PostAsJsonAsync<string>("https://localhost:7092/api/Users", json);
        }
    }
}

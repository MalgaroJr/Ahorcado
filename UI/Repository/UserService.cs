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
                string url = this.HttpClient.BaseAddress.ToString() + $"api/Users/{username}";
                var response = await this.HttpClient.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        throw new ArgumentNullException("username");
                    }
                    var usuario=response.Content.ReadAsStringAsync().Result;
                    u = JsonConvert.DeserializeObject<Usuario>(usuario);
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
            string url = this.HttpClient.BaseAddress.ToString() + "api/Users";
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

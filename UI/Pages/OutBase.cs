using Microsoft.AspNetCore.Components;
using UI.Repository.IServices;
using ClasesAhorcado;

namespace UI.Pages
{
    public class OutBase:ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected string user = "";
        protected string contra = "";
        protected string msg = "";

        public async Task<bool> Login(string username, string password)
        {
            var us = await UserService.GetUsuarioByUsername(username);
            if (us == null) { return false; }
            //var us = r.Result;
            if (us.Username.Equals(username) && us.Password.Equals(password)) 
            { 
                return true; 
            }
            return false;
        }
    }
}

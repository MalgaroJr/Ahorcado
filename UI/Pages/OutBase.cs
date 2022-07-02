using Microsoft.AspNetCore.Components;
using UI.Repository.IServices;

namespace UI.Pages
{
    public class OutBase:ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }
    }
}

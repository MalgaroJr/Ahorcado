using ClasesAhorcado;

namespace UI.Repository.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();

        Task<Usuario> GetUsuarioByUsername(string username);

        Task New(Usuario u);
    }
}

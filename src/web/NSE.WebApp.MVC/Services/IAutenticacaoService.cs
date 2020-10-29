using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
        Task<string> Login(UsuarioLoginViewModel usuarioLoginViewModel);
        
        Task<string> Registro(UsuarioRegistroViewModel usuarioRegistroViewModel);
    }
}

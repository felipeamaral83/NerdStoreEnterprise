using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLoginViewModel);
        
        Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistroViewModel);
    }
}

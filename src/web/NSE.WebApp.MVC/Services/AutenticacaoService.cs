using NSE.WebApp.MVC.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLoginViewModel)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuarioLoginViewModel),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44314/api/identidade/autenticar", content);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<UsuarioRespostaLoginViewModel>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistroViewModel)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuarioRegistroViewModel),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44314/api/identidade/nova-conta", content);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<UsuarioRespostaLoginViewModel>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}

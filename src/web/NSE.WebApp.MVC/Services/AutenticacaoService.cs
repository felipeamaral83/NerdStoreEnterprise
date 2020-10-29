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
        
        public async Task<string> Login(UsuarioLoginViewModel usuarioLoginViewModel)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuarioLoginViewModel),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("", content);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Registro(UsuarioRegistroViewModel usuarioRegistroViewModel)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuarioRegistroViewModel),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("", content);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }
}

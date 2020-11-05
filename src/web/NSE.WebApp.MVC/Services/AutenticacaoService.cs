using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(
            HttpClient httpClient,
            IOptions<AppSettings> appSettings)
        {
            httpClient.BaseAddress = new Uri(appSettings.Value.AutenticacaoUrl);
            _httpClient = httpClient;
        }
        
        public async Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLoginViewModel)
        {
            var content = ObterConteudo(usuarioLoginViewModel);

            var response = await _httpClient.PostAsync("api/identidade/autenticar", content);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLoginViewModel
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLoginViewModel>(response);
        }

        public async Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistroViewModel)
        {
            var content = ObterConteudo(usuarioRegistroViewModel);

            var response = await _httpClient.PostAsync("api/identidade/nova-conta", content);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLoginViewModel
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLoginViewModel>(response);
        }
    }
}

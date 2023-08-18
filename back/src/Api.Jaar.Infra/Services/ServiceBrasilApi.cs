using Api.Jaar.Domain.Responses;
using Api.Jaar.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Api.Jaar.Infra.Services
{
    public class ServiceBrasilApi : IServiceBrasilApi
    {
        private readonly HttpClient Http = new();
        private readonly string url = "https://brasilapi.com.br/api/fipe/preco/v1/";
                                       

        public ServiceBrasilApi()
        { }

        public async Task<BrasilApiResponse> BrasilApiPreco(int fipe, int anoModelo)
        {
            string codeFipe = fipe.ToString().PadLeft(7, '0');
            BrasilApiResponse brasilApiResponse = new BrasilApiResponse();

            try
            {
                var _returnApi = await Http.GetFromJsonAsync<List<BrasilApiResponse>>($"{url}{codeFipe}");

                return _returnApi.FirstOrDefault(x => x.AnoModelo.Equals(anoModelo));
            }
            catch (Exception ex)
            {
                return brasilApiResponse ;
            }
        }
    }
}
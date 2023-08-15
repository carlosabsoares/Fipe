using Api.Jaar.Domain.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Jaar.Domain.Servicos
{
    public interface IServiceBrasilApi
    {
        Task<BrasilApiResponse> BrasilApiPreco(int fipe, int anoModelo);
    }
}

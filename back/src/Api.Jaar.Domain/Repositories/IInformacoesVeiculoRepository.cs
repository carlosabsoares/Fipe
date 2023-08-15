using Api.Jaar.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Jaar.Domain.Repositories
{
    public interface IInformacoesVeiculoRepository : ICudRepository
    {
        Task<IList<InformacaoVeiculoEntity>> FindByCodigoAno(string codigoFipe, int anoModelo);
    }
}
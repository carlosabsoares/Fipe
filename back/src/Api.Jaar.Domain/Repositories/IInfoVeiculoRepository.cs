using Api.Jaar.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Jaar.Domain.Repositories
{
    public interface IInfoVeiculoRepository : ICudRepository
    {
        Task<IList<InfoVeiculoEntity>> FindByCodigoAno(string codigoFipe, int anoModelo);
    }
}
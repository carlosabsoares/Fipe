using Api.Jaar.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Jaar.Domain.Repositories
{
    public interface IInfoVeiculoRepository : ICudRepository
    {
        Task<InfoVeiculoEntity> FindByPlaca(string placa);
    }
}
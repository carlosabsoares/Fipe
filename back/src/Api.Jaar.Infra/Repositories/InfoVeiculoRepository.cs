using Api.Jaar.Domain.Entities;
using Api.Jaar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.Jaar.Infra.Repositories
{
    public class InfoVeiculoRepository : CudRepository, IInfoVeiculoRepository
    {
        private readonly DataContext _context;

        public InfoVeiculoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<InfoVeiculoEntity> FindByPlaca(string placa)
        {
            return await _context.InformacoesVeiculos.AsNoTracking()
                                           .FirstOrDefaultAsync(x => x.Placa.Equals(placa));
        }
    }
}
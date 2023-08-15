using Api.Jaar.Domain.Entities;
using Api.Jaar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Jaar.Infra.Repositories
{
    public class InformacoesVeiculoRepository : CudRepository, IInformacoesVeiculoRepository
    {
        private readonly DataContext _context;

        public InformacoesVeiculoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<InformacaoVeiculoEntity>> FindByCodigoAno(string codigoFipe, int anoModelo)
        {
            return await _context.InformacoesVeiculos.AsNoTracking()
                                           .Where(x => x.CodigoFipe.Equals(codigoFipe)
                                                                  && x.AnoModelo.Equals(anoModelo)).ToListAsync();
        }
    }
}
using Api.Jaar.Domain.Entities;
using Api.Jaar.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Api.Jaar.Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<InformacaoVeiculoEntity> InformacoesVeiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.MapInformacoesVeiculos(modelBuilder);
        }
    }
}
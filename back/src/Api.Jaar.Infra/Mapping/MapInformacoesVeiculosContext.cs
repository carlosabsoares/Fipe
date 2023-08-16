using Api.Jaar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Jaar.Infra.Mapping
{
    public static class MapInformacoesVeiculosContext
    {
        public static void MapInformacoesVeiculos(this DataContext context, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfoVeiculoEntity>().ToTable("InformacoesVeiculos");

            modelBuilder.Entity<InfoVeiculoEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<InfoVeiculoEntity>().HasIndex(x => x.Id);

            modelBuilder.Entity<InfoVeiculoEntity>().Property(x => x.AnoModelo);
            modelBuilder.Entity<InfoVeiculoEntity>().Property(x => x.CodigoFipe);
            modelBuilder.Entity<InfoVeiculoEntity>().Property(x => x.Placa);
        }
    }
}
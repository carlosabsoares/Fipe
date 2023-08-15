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
            modelBuilder.Entity<InfoVeiculoEntity>().HasKey(x => x.Valor);
            modelBuilder.Entity<InfoVeiculoEntity>().HasKey(x => x.Marca);
            modelBuilder.Entity<InfoVeiculoEntity>().HasKey(x => x.AnoModelo);
            modelBuilder.Entity<InfoVeiculoEntity>().HasKey(x => x.TipoCombustivel);
            modelBuilder.Entity<InfoVeiculoEntity>().HasKey(x => x.CodigoFipe);
            modelBuilder.Entity<InfoVeiculoEntity>().HasKey(x => x.TipoVeiculo);
            modelBuilder.Entity<InfoVeiculoEntity>().HasKey(x => x.TipoCombustivel);
        }
    }
}
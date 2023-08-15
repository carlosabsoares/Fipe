using Api.Jaar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Jaar.Infra.Mapping
{
    public static class MapInformacoesVeiculosContext
    {
        public static void MapInformacoesVeiculos(this DataContext context, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InformacaoVeiculoEntity>().ToTable("InformacoesVeiculos");

            modelBuilder.Entity<InformacaoVeiculoEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<InformacaoVeiculoEntity>().HasKey(x => x.Valor);
            modelBuilder.Entity<InformacaoVeiculoEntity>().HasKey(x => x.Marca);
            modelBuilder.Entity<InformacaoVeiculoEntity>().HasKey(x => x.AnoModelo);
            modelBuilder.Entity<InformacaoVeiculoEntity>().HasKey(x => x.TipoCombustivel);
            modelBuilder.Entity<InformacaoVeiculoEntity>().HasKey(x => x.CodigoFipe);
            modelBuilder.Entity<InformacaoVeiculoEntity>().HasKey(x => x.TipoVeiculo);
            modelBuilder.Entity<InformacaoVeiculoEntity>().HasKey(x => x.TipoCombustivel);
        }
    }
}
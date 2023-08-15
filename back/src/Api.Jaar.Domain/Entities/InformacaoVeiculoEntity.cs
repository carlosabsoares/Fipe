using Api.Jaar.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Api.Jaar.Domain.Entities
{
    public class InformacaoVeiculoEntity : Entity
    {
        public decimal Valor { get; set; } = 0;

        [MinLength(2)]
        [MaxLength(60)]
        public string Marca { get; set; } = null;

        [MinLength(2)]
        [MaxLength(60)]
        public string Modelo { get; set; } = null;
        public int AnoModelo { get; set; }

        [MinLength(2)]
        [MaxLength(8)]
        public string CodigoFipe { get; set; }
        public EnTipoVeiculo TipoVeiculo { get; set; } = EnTipoVeiculo.Automovel;
        public EnTipoCombustivel TipoCombustivel { get; set; } = EnTipoCombustivel.G;
    }
}
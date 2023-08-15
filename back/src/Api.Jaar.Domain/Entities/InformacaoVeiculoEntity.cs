using Api.Jaar.Domain.Entities.Enum;

namespace Api.Jaar.Domain.Entities
{
    public class InformacaoVeiculoEntity : Entity
    {
        public decimal Valor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoModelo { get; set; }
        public string CodigoFipe { get; set; }
        public EnTipoVeiculo TipoVeiculo { get; set; } = EnTipoVeiculo.Automovel;
        public EnTipoCombustivel TipoCombustivel { get; set; } = EnTipoCombustivel.G;
    }
}
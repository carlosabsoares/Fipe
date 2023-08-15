using System.Text.Json.Serialization;

namespace Api.Jaar.Domain.Responses
{
    public class BrasilApiResponse
    {
        public string CodigoFipe { get; set; }
        public string Valor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoModelo { get; set; }
        public string Combustivel { get; set; }

    }
}

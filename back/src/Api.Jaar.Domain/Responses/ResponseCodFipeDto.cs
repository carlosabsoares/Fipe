using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Jaar.Domain.Responses
{
    public class ResponseCodFipeDto
    {
        public string Fipe { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int AnoModelo { get; set; }
        public string Combustivel { get; set; } = string.Empty;
    }
}

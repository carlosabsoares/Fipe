using Api.Jaar.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Api.Jaar.Domain.Entities
{
    public class InfoVeiculoEntity : Entity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(8)]
        public string CodigoFipe { get; set; }

        [Required]
        public int AnoModelo { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(8)]
        public string Placa { get; set; } = null;
    }
}
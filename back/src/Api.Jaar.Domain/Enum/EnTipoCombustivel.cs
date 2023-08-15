using System.ComponentModel;

namespace Api.Jaar.Domain.Entities.Enum
{
    public enum EnTipoCombustivel
    {
        [Description("Gasolina")]
        G = 0,

        [Description("Álcool")]
        A = 1,

        [Description("Flex")]
        F = 2,

        [Description("Diesel")]
        D = 3,

        [Description("Híbrido")]
        H = 4,

        [Description("Elétrico")]
        E = 5
    }
}
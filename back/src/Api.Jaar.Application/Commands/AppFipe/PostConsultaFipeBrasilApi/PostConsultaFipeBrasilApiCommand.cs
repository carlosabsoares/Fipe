using Api.Jaar.Application.Configuration.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Api.Jaar.Application.Commands.AppFipe
{
    public class PostConsultaFipeBrasilApiCommand : Notifiable, ICommand
    {
        public int AnoModelo { get; set; }
        public int CodigoFipe { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsTrue(AnoModelo > 0, "AnoModelo", "Ano deve ser maior que zero")
                    .IsTrue(CodigoFipe > 0, "CodigoFipe", "Código Fipe deve ser maior que zero")
            );
        }
    }
}

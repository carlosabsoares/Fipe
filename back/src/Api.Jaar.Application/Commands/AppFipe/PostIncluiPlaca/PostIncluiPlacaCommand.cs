using Api.Jaar.Application.Configuration.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Api.Jaar.Application.Commands.AppFipe
{
    public class PostIncluiPlacaCommand : Notifiable, ICommand
    {
        public int AnoModelo { get; set; }
        public int CodigoFipe { get; set; }
        public string Placa { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Placa, "Placa", "Placa não pode ser nula ou vazia")
                    .IsTrue(AnoModelo > 0, "AnoModelo", "Ano deve ser maior que zero")
                    .IsTrue(CodigoFipe > 0, "CodigoFipe", "Código Fipe deve ser maior que zero")
            );
        }
    }
}
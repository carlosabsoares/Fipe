using Api.Jaar.Application.Configuration.Commands;
using Api.Jaar.Application.Configuration.Queries;
using Flunt.Notifications;
using Flunt.Validations;

namespace Api.Jaar.Application.Commands.AppFipe
{
    public class GetConsultarPlacaQuery : Notifiable, IQuery
    {
        public string Placa { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Placa, "Placa", "Placa não pode ser nula ou vazia")
            );
        }
    }
}
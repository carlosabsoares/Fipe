using Api.Jaar.Application.Configuration.Events;
using Flunt.Validations;
using MediatR;

namespace Api.Jaar.Application.Configuration.Commands
{
    public interface ICommand : IRequest<IEvent>, IValidatable
    {
    }
}
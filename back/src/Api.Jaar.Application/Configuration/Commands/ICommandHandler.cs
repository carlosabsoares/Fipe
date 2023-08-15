using Api.Jaar.Application.Configuration.Events;
using MediatR;

namespace Api.Jaar.Application.Configuration.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, IEvent> where TCommand : ICommand
    {
    }
}
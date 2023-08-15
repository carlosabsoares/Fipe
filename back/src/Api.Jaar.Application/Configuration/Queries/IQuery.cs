using Api.Jaar.Application.Configuration.Events;
using Flunt.Validations;
using MediatR;

namespace Api.Jaar.Application.Configuration.Queries
{
    public interface IQuery : IRequest<IEvent>, IValidatable
    {
    }
}
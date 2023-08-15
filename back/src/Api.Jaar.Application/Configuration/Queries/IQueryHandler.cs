using Api.Jaar.Application.Configuration.Events;
using MediatR;

namespace Api.Jaar.Application.Configuration.Queries
{
    public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery, IEvent> where TQuery : IQuery
    {
    }
}
using MediatR;

namespace GrantAdvance.Backend.Application.Abstractions.Messaging.Query;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
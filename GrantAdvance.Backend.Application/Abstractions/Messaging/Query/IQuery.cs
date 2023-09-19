using MediatR;

namespace GrantAdvance.Backend.Application.Abstractions.Messaging.Query;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
using MediatR;

namespace GrantAdvance.Backend.Application.Abstractions.Messaging.Command;

public interface ICommand : IRequest, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<TReponse>, IBaseCommand
{
}
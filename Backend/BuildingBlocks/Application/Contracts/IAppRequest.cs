
using MediatR;

namespace Application.Contracts;

public interface IAppRequest<out TResponse> : IRequest<TResponse> 
{
}
public interface IAppRequest : IRequest { }

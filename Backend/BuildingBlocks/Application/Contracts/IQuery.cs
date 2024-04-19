namespace Application.Contracts;

public interface IQuery<out TResponse>:IAppRequest<TResponse>
{
}

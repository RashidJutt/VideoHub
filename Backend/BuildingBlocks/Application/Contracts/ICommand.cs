namespace Application.Contracts;

public interface ICommand : IAppRequest { }

public interface ICommand<out TResponse> : IAppRequest<TResponse> { }

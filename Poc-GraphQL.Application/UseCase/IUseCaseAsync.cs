using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Application.UseCase
{
    public interface IUseCaseAsync<TRequest>
    {
        Task ExecuteAsync(TRequest request);
    }

    public interface IUseCaseAsyncR<TResponse>
    {
        TResponse ExecuteAsync();
    }

    public interface IUseCaseAsync<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}

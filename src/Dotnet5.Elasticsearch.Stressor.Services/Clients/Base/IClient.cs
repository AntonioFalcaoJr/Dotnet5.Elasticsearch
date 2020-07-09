using System.Threading;
using System.Threading.Tasks;
using Dotnet5.Elasticsearch.Domain.Abstractions;

namespace Dotnet5.Elasticsearch.Stressor.Services.Clients.Base
{
    public interface IClient<in TEntity, TClientModel, TId>
        where TClientModel : ClientModel<TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        Task<TClientModel> DeleteAsync(CancellationToken cancellationToken);
        Task<TClientModel> GetAsync(CancellationToken cancellationToken);
        Task<TClientModel> PostAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TClientModel> PutAsync(CancellationToken cancellationToken);
    }
}
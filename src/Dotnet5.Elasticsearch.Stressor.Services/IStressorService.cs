using System.Threading;
using System.Threading.Tasks;

namespace Dotnet5.Elasticsearch.Stressor.Services
{
    public interface IStressorService
    {
        Task ExcludeAsync(CancellationToken cancellationToken);
        Task GenerateAsync(int amount, CancellationToken cancellationToken);
        Task ModifyAsync(CancellationToken cancellationToken);
    }
}
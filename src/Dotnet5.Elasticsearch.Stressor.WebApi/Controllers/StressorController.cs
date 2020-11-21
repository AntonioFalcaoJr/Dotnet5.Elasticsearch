using System.Threading;
using System.Threading.Tasks;
using Dotnet5.Elasticsearch.Stressor.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet5.Elasticsearch.Stressor.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StressorController : ControllerBase
    {
        private readonly IStressorService _stressorService;

        public StressorController(IStressorService stressorService)
        {
            _stressorService = stressorService;
        }

        [HttpGet]
        public async Task<ActionResult> ExcludeAsync(CancellationToken cancellationToken, [FromQuery] int amount = 1)
        {
            await _stressorService.ExcludeAsync(cancellationToken);
            return Ok($"Requested exclude {amount} Cards");
        }

        [HttpGet]
        public async Task<ActionResult> GenerateAsync(CancellationToken cancellationToken, [FromQuery] int amount = 1)
        {
            await _stressorService.GenerateAsync(amount, cancellationToken);
            return Ok($"Requested generate {amount} Cards");
        }

        [HttpGet]
        public async Task<ActionResult> ModifyAsync(CancellationToken cancellationToken, [FromQuery] int amount = 1)
        {
            await _stressorService.ModifyAsync(cancellationToken);
            return Ok($"Requested modify {amount} Cards");
        }
    }
}
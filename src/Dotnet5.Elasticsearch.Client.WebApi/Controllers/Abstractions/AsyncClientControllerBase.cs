using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.Elasticsearch.Domain.Abstractions;
using Dotnet5.Elasticsearch.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet5.Elasticsearch.Client.WebApi.Controllers.Abstractions
{
    public abstract class AsyncClientControllerBase<TEntity, TModel, TId> : ControllerBase
        where TEntity : Entity<TId>
        where TModel : Model<TId>
        where TId : struct
    {
        private readonly IService<TEntity, TModel, TId> _service;

        protected AsyncClientControllerBase(IService<TEntity, TModel, TId> service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            if (Equals(id, default(TId))) return BadRequest("Identificador inválido.");
            if (await _service.ExistsAsync(id, cancellationToken) == false) return NotFound();
            await _service.DeleteAsync(id, cancellationToken);
            return Accepted();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _service.GetAllAsync(cancellationToken);
            if (entities?.Any() == false) return NoContent();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            if (Equals(id, default(TId))) return BadRequest("Identificador inválido.");
            var entity = await _service.GetByIdAsync(id, cancellationToken);
            if (entity is null) return NotFound();
            if (entity.IsValid is false) return BadRequest(entity.Notification.Error);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TModel model, CancellationToken cancellationToken)
        {
            if (Equals(model.Id, default(TId))) return BadRequest("Identificador inválido.");
            if (await _service.ExistsAsync(model.Id, cancellationToken)) return Conflict();
            var entity = await _service.SaveAsync(model, cancellationToken);
            if (entity.IsValid is false) return BadRequest(entity.Notification.Error);

            return CreatedAtAction(nameof(GetByIdAsync),
                new {id = entity.Id, cancellationToken, version = HttpContext.GetRequestedApiVersion()?.ToString()}, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(TId id, [FromBody] TModel model, CancellationToken cancellationToken)
        {
            if (Equals(id, default(TId))) return BadRequest("Identificador inválido.");
            if (Equals(model.Id, id) is false) return UnprocessableEntity("Identificador diverge do objeto solicitado.");
            if (await _service.ExistsAsync(id, cancellationToken) is false) return NotFound();
            var entity = await _service.EditAsync(model, cancellationToken);
            if (entity.IsValid is false) return BadRequest(entity.Notification.Error);
            return Ok(entity);
        }
    }
}
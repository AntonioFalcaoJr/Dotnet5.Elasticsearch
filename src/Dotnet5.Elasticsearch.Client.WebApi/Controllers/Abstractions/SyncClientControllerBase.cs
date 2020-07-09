using System.Collections.Generic;
using System.Linq;
using Dotnet5.Elasticsearch.Domain.Abstractions;
using Dotnet5.Elasticsearch.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet5.Elasticsearch.Client.WebApi.Controllers.Abstractions
{
    public abstract class SyncClientControllerBase<TEntity, TModel, TId> : ControllerBase
        where TEntity : Entity<TId>
        where TModel : Model<TId>
        where TId : struct
    {
        private readonly IService<TEntity, TModel, TId> _service;

        protected SyncClientControllerBase(IService<TEntity, TModel, TId> service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(TId id)
        {
            if (Equals(id, default(TId))) return BadRequest("Identificador inválido.");
            if (_service.Exists(id) is false) return NotFound();
            _service.Delete(id);
            return Accepted();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TEntity>> GetAll()
        {
            var entities = _service.GetAll();
            if (entities?.Any() == false) return NoContent();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(TId id)
        {
            if (Equals(id, default(TId))) return BadRequest("Identificador inválido.");
            var entity = _service.GetById(id);
            if (entity is null) return NotFound();
            if (entity.IsValid is false) return BadRequest(entity.Notification.Error);
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TModel model)
        {
            if (Equals(model.Id, default(TId))) return BadRequest("Identificador inválido.");
            if (_service.Exists(model.Id)) return Conflict();
            var entity = _service.Save(model);
            if (entity.IsValid is false) return BadRequest(entity.Notification.Error);

            return CreatedAtAction(nameof(GetById),
                new {id = entity.Id, version = HttpContext.GetRequestedApiVersion()?.ToString()}, entity);
        }

        [HttpPut("{id}")]
        public IActionResult Put(TId id, [FromBody] TModel model)
        {
            if (Equals(id, default(TId))) return BadRequest("Identificador inválido.");
            if (Equals(model.Id, id) is false) return UnprocessableEntity("Identificador diverge do objeto solicitado.");
            if (_service.Exists(id) is false) return NotFound();
            var entity = _service.Edit(model);
            if (entity.IsValid is false) return BadRequest(entity.Notification.Error);
            return Ok(entity);
        }
    }
}
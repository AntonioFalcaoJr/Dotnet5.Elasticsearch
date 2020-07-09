using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.Elasticsearch.Domain.Abstractions;
using Dotnet5.Elasticsearch.Repositories.Abstractions.Extensions;
using Microsoft.Extensions.Logging;
using Nest;

namespace Dotnet5.Elasticsearch.Repositories.Abstractions.NoSqls
{
    public abstract class NoSqlRepository<TEntity, TId> : INoSqlRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly IElasticClient _elasticClient;
        private readonly ILogger<NoSqlRepository<TEntity, TId>> _logger;

        protected NoSqlRepository(IElasticClient elasticClient, ILogger<NoSqlRepository<TEntity, TId>> logger)
        {
            _elasticClient = elasticClient;
            _logger = logger;
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (entity is null) return default;
            var response = _elasticClient.IndexDocument(entity);
            _logger.LogResponse(response);
            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity is null) return default;
            var response = await _elasticClient.IndexDocumentAsync(entity, cancellationToken);
            _logger.LogResponse(response);
            return entity;
        }

        public virtual void Delete(TId id)
        {
            if (Equals(id, default(TId))) return;
            var entity = GetById(id);
            if (entity is null) return;
            var response = _elasticClient.Delete<TEntity>(entity);
            _logger.LogResponse(response);
        }

        public virtual async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            if (Equals(id, default(TId))) return;
            var entity = await GetByIdAsync(id, cancellationToken);
            if (entity is null) return;
            var response = await _elasticClient.DeleteAsync<TEntity>(entity, ct: cancellationToken);
            _logger.LogResponse(response);
        }

        public virtual bool Exists(TId id)
        {
            if (Equals(id, default(TId))) return default;
            var response = _elasticClient.DocumentExists<TEntity>(id.ToString());
            return response.Exists;
        }

        public virtual async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken)
        {
            if (Equals(id, default(TId))) return default;
            var response = await _elasticClient.DocumentExistsAsync<TEntity>(id.ToString(), ct: cancellationToken);
            return response.Exists;
        }

        public virtual TEntity GetById(TId id)
        {
            if (Equals(id, default(TId))) return default;
            var response = _elasticClient.Get<TEntity>(id.ToString());
            _logger.LogResponse(response);
            return response.Source;
        }

        public virtual async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            if (Equals(id, default(TId))) return default;
            var response = await _elasticClient.GetAsync<TEntity>(id.ToString(), ct: cancellationToken);
            _logger.LogResponse(response);
            return response.Source;
        }

        public virtual void Update(TEntity entity)
        {
            if (entity is null) return;
            var response = _elasticClient.Update<TEntity>(entity, descriptor => descriptor.Doc(entity));
            _logger.LogResponse(response);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity is null) return;
            var response = await _elasticClient.UpdateAsync<TEntity>(entity, descriptor
                => descriptor.Doc(entity), cancellationToken);
            _logger.LogResponse(response);
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = default)
        {
            var response = _elasticClient.Search<TEntity>(descriptor => descriptor.MatchAll());
            _logger.LogResponse(response);
            return response?.Documents;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = default, CancellationToken
            cancellationToken = default)
        {
            var response = await _elasticClient.SearchAsync<TEntity>(searchDescriptor
                => searchDescriptor.MatchAll(), cancellationToken);
            _logger.LogResponse(response);
            return response?.Documents;
        }
    }
}
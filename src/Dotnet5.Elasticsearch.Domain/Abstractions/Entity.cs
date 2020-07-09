using Dotnet5.Elasticsearch.CrossCutting.Notifications;

namespace Dotnet5.Elasticsearch.Domain.Abstractions
{
    public abstract class Entity<TId>
        where TId : struct
    {
        protected Entity()
        {
            Notification = new Notification();
        }

        public TId Id { get; protected set; }
        public bool IsValid => Notification?.HasErrors is false;
        public INotification Notification { get; }

        protected abstract void SetId(TId id);
    }
}
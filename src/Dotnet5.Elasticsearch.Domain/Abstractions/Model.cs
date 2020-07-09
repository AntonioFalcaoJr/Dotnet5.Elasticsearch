using Dotnet5.Elasticsearch.CrossCutting.Notifications;

namespace Dotnet5.Elasticsearch.Domain.Abstractions
{
    public abstract class Model<TId>
        where TId : struct
    {
        protected Model()
        {
            Notification = new Notification();
        }

        public virtual TId Id { get; set; }
        public bool IsValid => Notification?.HasErrors == false;

        public INotification Notification { get; }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Dotnet5.Elasticsearch.CrossCutting.Notifications
{
    public class Notification : INotification
    {
        public Notification()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; }

        public bool HasErrors => Errors?.Any() ?? default;

        public string Error => string.Join(", ", Errors);

        public void AddError(string error) => Errors.Add(error);

        public void AddError(INotification notification) => AddErrors(notification?.Errors);

        public void AddError(string error, INotification externalNotification)
        {
            AddError(error);
            AddErrors(externalNotification?.Errors);
        }

        public void AddErrors(IEnumerable<INotification> notifications)
            => AddErrors(notifications?.SelectMany(notification => notification?.Errors));

        public void AddErrors(IEnumerable<string> errors)
        {
            if (errors is null) return;
            Errors.AddRange(errors);
        }
    }
}
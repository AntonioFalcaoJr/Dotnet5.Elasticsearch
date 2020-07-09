namespace Dotnet5.Elasticsearch.Domain.Abstractions
{
    public abstract class ClientModel<TId> : Model<TId>
        where TId : struct
    {
        public string Result { get; set; }
    }
}
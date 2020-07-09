# .NET 5 + Elasticsearch + NEST
###### WIP - Work in progress


This project aims to explore how NEST works with Elasticsearch in .NET 5 projects.

## Getting Started

After the project clone follow the steps described in the [installing](#installing). 

> HTTPS
>```bash
>git clone https://git-unj.softplan.com.br/antonio.falcao/Dotnet5.Elasticsearch.git
>```
> SSH
>```bash
>git clone git@git-unj.softplan.com.br:antonio.falcao/Dotnet5.Elasticsearch.git
>```

### Prerequisites

* [.NET 5](https://github.com/dotnet/core/blob/master/release-notes/5.0/preview/5.0.0-preview.5-install-instructions.md) - The framework used

> To check this functionality:
>```bash
>dotnet --version
>```
> For more details
>```bash
>dotnet --info
>```

* [Docker](https://www.docker.com/) - The container platform used
> To check this functionality:
>```bash
>docker --version
>```

### Installing

With the use of **containerization**, we can practically orchestrate the necessary infrastructure.

You will need an **Elastic Search** cluster + **Kibana** , to meet the need for _Search Engine_, so you must run the respective [docker-compose](./.elasticsearch/docker-compose.yml) on your Elasticsearch server.

```bash
cd ./.elasticsearch/
docker-compose up -d
```

Is important to say, if occurrence problems with max virtual memory area:

```bash
docker logs es01

# comment for brevity

ERROR: [1] bootstrap checks failed
[1]: max virtual memory areas vm.max_map_count [65530] is too low, increase to at least [262144]
```  

It's possible to increase to at least [262144]:

```bash
sudo sysctl -w vm.max_map_count=262144
``` 

> More details about in this [link](https://www.elastic.co/guide/en/elasticsearch/reference/7.5/docker.html#docker-prod-prerequisites)

The **Kibana** service will be available in default host `http://localhost:5601`, as defined on compose.

```yaml
  kib01:
    image: docker.elastic.co/kibana/kibana:7.6.0
    container_name: kib01
    ports:
      - 5601:5601
    environment:
      ELASTICSEARCH_URL: http://es01:9200
      ELASTICSEARCH_HOSTS: http://es01:9200

# comment for brevity
```

#### App settings

After providing the necessary infrastructure, we need to define the cluster **index** and **nodes** addresses on the [`appsettings`](./src/Dotnet5.Elasticsearch.Client.WebApi/appsettings.json) from the [`Elasticsearch.Client.WebApi`](./src/Dotnet5.Elasticsearch.Client.WebApi) project.

```json
{
  "Elasticsearch": {
    "index": "card",
    "node1Uri": "http://192.168.0.27:9200/",
    "node2Uri": "http://192.168.0.27:9201/",
    "node3Uri": "http://192.168.0.27:9202/",
    "node4Uri": "http://192.168.0.27:9203/",
    "node5Uri": "http://192.168.0.27:9204/"
  }
}
```

And then set the HTTP client host on [`appsettings`](./src/Dotnet5.Elasticsearch.Stressor.WebApi/appsettings.json) from [`Elasticsearch.Stressor.WebApi`](./src/Dotnet5.Elasticsearch.Stressor.WebApi) project.

```json
{
  "ElasticsearchClient": {
    "Url": "http://192.168.0.27:5000"
  }
}
```

## Running

The respective [compose](./docker-compose.yml) provide the `client` and `stressor` services:

```
docker-compose up -d
```

#### Stressor and Client services

The **Stressor** service provide  resources to request  _generate_, _modify_, and _remove_ data from Elasticsearch through the **client** service.

Is just run the compose from the app to up both of then in the same network. In this way is possible to use services names on the [appsettings](#app-settings).     

> The **Client** routing uses the default `http://hostname:port/api/v{version}/controller`. Where  **/v1** is Synchronous and **/v2** is Asynchronous.

> The **Stressor** routing uses the default `http://hostname:port/controller/action`.

To make API calls, you can use the file [./basic-api-call.http](./basic-api-call.http) through extension [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client):

```http request
# [STRESSOR]
###
GET http://localhost:6000/stressor/generate?amount=10

###
GET http://localhost:6000/stressor/modify?amount=10

### 
GET http://localhost:6000/stressor/exclude?amount=10


# [CLIENT]
### 
GET http://localhost:5000/api/v2/card

###
GET http://localhost:5000/api/v2/card/f694491b-bc98-45bc-af97-67f7ac460908
```

## Built With

##### Microsoft Stack
* [.NET 5](https://dotnet.microsoft.com/) - The base framework used
* [ASP.NET 5](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1) - The web framework used
* [AutoMapper](https://automapper.org/) - Library for mapping objects

##### Elasticsearch Stack
* [Elasticsearch](https://www.elastic.co) - Search Engine used.
* [NEST](https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/nest.html) - Elasticsearch client for .NET
* [Kibana](https://www.elastic.co/pt/kibana) - Elasticsearch visualize and analyze service

## Contributing

Available soon! 

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/AntonioFalcao/SolrDotnetSample/tags). 

## Authors

* **Antônio Falcão** - [GitHub](https://github.com/AntonioFalcao)

> See also the list of [contributors](https://github.com/AntonioFalcao/SolrDotnetSample/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Nothing more, for now.
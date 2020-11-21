using Microsoft.AspNetCore.Mvc;

namespace Dotnet5.Elasticsearch.Client.WebApi.Controllers.Abstractions
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase { }
}
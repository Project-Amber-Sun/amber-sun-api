using Microsoft.AspNetCore.Mvc;
using Amber.Sun.Domain.Catalog;

namespace Amber.Sun.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CatalogController : ControllerBase
    [HttpGet]
    {
        public IActionResult GetItems(){
            return Ok("Hello World!")
        }
    
}
}
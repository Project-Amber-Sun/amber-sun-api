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
            var items = new List<Item>()
            {
                new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m),
                new Item("Shorts", "Ohio State Shorts", "Nike", 49.99m),
        };
            };
            return Ok(items);
        }

        [HttpGet("{id:int}")]

        public IActionResult GetItem(int id)
        {
            var item = new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m);
            item.Id = id;
            return Ok(item);   
}

        [HttpPost]
        public IActionResult Post(Item item){
    return Created("catalog/42", item);
}

        [HttpPost("{id}/ratings")]
        public IActionResult PostRating(int id, [From Body] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);
            return Ok(item);
        }
        [httpput]

        public IActionResult Put(int id, Item item){
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
}
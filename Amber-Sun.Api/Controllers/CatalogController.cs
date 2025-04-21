using Microsoft.AspNetCore.Mvc;
using Amber.Sun.Domain.Catalog;
using Amber.Sun.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace Amber.Sun.Api.Controllers
{
    ### Get token from Auth0
    curl --request POST \
  --url https://dev-e5y2va5cni4m1e4c.us.auth0.com/oauth/token \
  --header 'content-type: application/json' \
  --data '{"client_id":"IQUTpN3JG7bSXZZCl5u5qNx1A1xi2wMN","client_secret":"YmdLW7Sre5RUc8ueQw3oZEhAISGE-YznGPXuNVj4LySAs-i8CT--OXBIN5X0TGAu","audience":"https://Amber-Sun","grant_type":"client_credentials"}'
   
    [ApiController]
    [Route("/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;

        public CatalogController(StoreContext db){
            _db = db;
        }
        [HttpGet] 
        public IActionResult GetItems()
        {
            return Ok(_db.Items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
           _db.Items.Add(item);
           _db.SaveChanges();
           return Created($"/catalog/{item.Id}", item);
        }

        [HttpPost("{id}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            { 
                return NotFound();
            }

            item.AddRating(rating);
            _db.SaveChanges();

            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            if (_db.Items.Find(id) == null)
            {
                return NotFound();
            }

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id:int}")]
        [Authorize("delete:catalog")]
        public IActionResult Delete(int id)
        {
            var item = _db.Items.Find(id);
            
        }
        public IActionResult Delete(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok();
        }
    }
}

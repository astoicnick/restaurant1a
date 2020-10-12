using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantAPI.Controllers
{
    // CRUD here like repo
    [RoutePrefix("api/restaurant")]
    public class RestaurantController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // Create | POST api/restaurant
        [HttpPost]
        public async Task<IHttpActionResult> CreateRestaurant([FromBody] Restaurant restaurantToCreate)
        {
            Restaurant createdRestaurant = _context.Restaurants.Add(restaurantToCreate);

            await _context.SaveChangesAsync();

            return Ok(createdRestaurant);
        }

        // Read all | GET api/restaurant
        // [Attribute for HTTP Method]
        // [Attribute for the route(if not default)]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllRestaurants()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();

            return Ok(restaurants);
        }

        // Read single | GET api/restaurant/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetSingleRestaurant([FromUri] int id)
        {
            Restaurant requestedRestaurant = await _context.Restaurants.FindAsync(id);

            if (requestedRestaurant == null)
            {
                return NotFound();
            }

            return Ok(requestedRestaurant);
        }
        // Update
        
        // Delete
    }
}

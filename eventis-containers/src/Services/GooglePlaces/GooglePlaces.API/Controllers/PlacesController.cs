using System.Collections.Generic;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GooglePlaces.API.Controllers
{
    [Route("api/v1/places")]
    public class PlaceController : Controller
    {
        private readonly IPlaceRepository _repository;

        public PlaceController(IPlaceRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Place> Get()
        {
            return _repository.GetAll();
        }

        /*[HttpGet("{name}")]
        public IEnumerable<Place> Get(string name)
        {
            return _repository.GetByName(name);
        }*/

        // POST api/v1/place
        [HttpPost]
        public IActionResult Post([FromBody]Place place)
        {
            if (place == null)
            {
                return BadRequest();
            }

            var entity = Place.Create(place.Name, place.Rating, place.Address, place.Latitude, place.Longitude,
                place.OpenNow);

            _repository.Add(entity);
            _repository.SaveChanges();

            return Ok(place);
        }
    }
}

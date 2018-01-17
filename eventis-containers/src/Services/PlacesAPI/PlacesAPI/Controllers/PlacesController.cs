using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlacesAPI.DAL;
using PlacesAPI.Entities;

namespace PlacesAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/places")]
    public class PlacesController : Controller
    {
        private IPlaceRepository _context;

        public PlacesController(IPlaceRepository context)
        {
            _context = context;
        }

        [HttpGet("{id:Guid}", Name = "GetPlaceById")]
        public IActionResult GetById(Guid id)
        {
            var item = _context.GetPlaceById(id);

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var place = _context.GetPlaceById(id);

            if (place == null)
            {
                return NotFound();
            }

            _context.DeletePlace(id);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpGet("/getplaces/{givenType}")]
        public IEnumerable<Place> GetPlaces(string givenType)
        {
            _context.DeleteAll();
            _context.GetPlacesIasi(givenType);
            _context.SaveChanges();

            return _context.GetAllPlaces();
        }
    }
}
using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;
using FinalProject.WebIII.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WebIII.Controllers
{
    [ApiController]
    [Route("[controller]/cityEvent")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CityEventController : ControllerBase
    {
        public ICityEventServices _cityEventServices;

        public CityEventController(ICityEventServices cityEventServices)
        {
            _cityEventServices = cityEventServices;
        }

        [HttpGet("/cityEvents/Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CityEvent>> GetCityEvents()
        {
            return Ok(_cityEventServices.GetEvents());
        }

        [HttpGet("/cityEvents/GetById/{idEvent}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CityEvent> GetCityEventById(long idEvent)
        {
            if(_cityEventServices.GetEventById(idEvent) == null)
            {
                return NotFound();
            }
            return Ok(_cityEventServices.GetEventById(idEvent));
        }

        [HttpGet("cityEvents/GetByName/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CityEvent>> GetEventsByName(string title)
        {
            if(_cityEventServices.GetEventsByName(title) == null)
            {
                return NotFound();
            }
            return Ok(_cityEventServices.GetEventsByName(title));
        }

        [HttpGet("GetByLocal/{local}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CityEvent>> GetEventsByLocal(string local)
        {
            if (_cityEventServices.GetEventsByLocal(local) == null)
            {
                return NotFound();
            }
            return Ok(_cityEventServices.GetEventsByLocal(local));
        }

        [HttpGet("GetByDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CityEvent>> GetEventsByDate([FromQuery]DateTime dateHourEvent)
        {
            if (_cityEventServices.GetEventsByDate(dateHourEvent) == null)
            {
                return NotFound();
            }
            return Ok(_cityEventServices.GetEventsByDate(dateHourEvent));
        }

        [HttpGet("GetByPriceRange")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CityEvent>> GetEventsByPriceRange(decimal price1, decimal price2)
        {
            if (_cityEventServices.GetEventsByPriceRange(price1, price2) == null)
            {
                return NotFound();
            }
            return Ok(_cityEventServices.GetEventsByPriceRange(price1, price2));
        }

        [HttpPost("/cityEvents/Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(CheckExistingIdEvent))]
        public ActionResult<CityEvent> PostCityEvent(CityEvent cityEvent)
        {
            if(!_cityEventServices.CreateEvent(cityEvent))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(PostCityEvent), cityEvent);
        }

        [HttpPut("/cityEvents/Update/{idEvent}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutCityEvent(long idEvent, CityEvent cityEvent)
        {
            if (!_cityEventServices.UpdateEvent(idEvent, cityEvent))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("cityEvents/Delete/{idEvent}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCityEvent(long idEvent)
        {
            if (!_cityEventServices.DeleteEvent(idEvent))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
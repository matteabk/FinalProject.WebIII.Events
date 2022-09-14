using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;
using FinalProject.WebIII.Filters;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetByLocalAndDate/{local}/date")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CityEvent>> GetEventsByLocalAndDate(string local, [FromQuery]DateTime dateHourEvent)
        {
            if (_cityEventServices.GetEventsByLocalAndDate(local, dateHourEvent) == null)
            {
                return NotFound();
            }
            return Ok(_cityEventServices.GetEventsByLocalAndDate(local, dateHourEvent));
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

        [HttpGet("GetByPriceRangeAndDate")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CityEvent>> GetEventsByPriceRangeAndDate(decimal price1, decimal price2, DateTime dateHourEvent)
        {
            if (_cityEventServices.GetEventsByPriceRangeAndDate(price1, price2, dateHourEvent) == null)
            {
                return NotFound();
            }
            return Ok(_cityEventServices.GetEventsByPriceRangeAndDate(price1, price2, dateHourEvent));
        }

        [HttpPost("/cityEvents/Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(CheckExistingIdEvent))]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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
        [ServiceFilter(typeof(CheckReservationsForEvents))]
        [Authorize(Roles = "admin")]
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
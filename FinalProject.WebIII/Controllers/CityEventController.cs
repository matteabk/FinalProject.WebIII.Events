using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;
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

        [HttpGet("/cityEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CityEvent>> GetCityEvents()
        {
            return Ok(_cityEventServices.GetEvents());
        }

        [HttpGet("/cityEvents/{idEvent}")]
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

        [HttpPost("/cityEvents/Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
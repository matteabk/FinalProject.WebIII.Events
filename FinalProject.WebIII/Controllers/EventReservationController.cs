using Microsoft.AspNetCore.Mvc;
using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;

namespace FinalProject.WebIII.Controllers
{
    [ApiController]
    [Route("[controller]/EventReservation")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : ControllerBase
    {
        public IEventReservationServices _eventReservationServices;

        public EventReservationController(IEventReservationServices eventReservationServices)
        {
            _eventReservationServices = eventReservationServices;
        }

        [HttpGet("/eventReservation/Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<EventReservation>> GetEventReservations()
        {
            return Ok(_eventReservationServices.GetReservations());
        }

        [HttpGet("/eventReservation/GetById/{idReservation}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EventReservation> GetEventReservationById(long idReservation)
        {
            if(_eventReservationServices.GetReservationById(idReservation) == null)
            {
                return NotFound();
            }
            return Ok(_eventReservationServices.GetReservationById(idReservation));
        }

        [HttpGet("/eventReservation/GetByPersonNameAndEventTitle/{personName}/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EventReservation> GetReservationByPersonNameAndTitle(string personName, string title)
        {
            if (_eventReservationServices.GetReservationsByNameAndTitle(personName, title) == null)
            {
                return NotFound();
            }
            return Ok(_eventReservationServices.GetReservationsByNameAndTitle(personName, title));
        }

        [HttpPost("/eventReservation/Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EventReservation> PostEventReservation(EventReservation eventReservation)
        {
            if(!_eventReservationServices.CreateReservation(eventReservation))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(PostEventReservation), eventReservation);
        }

        [HttpPut("/eventReservation/Update/{idReservation}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutEventReservation(long idReservation, EventReservation eventReservation)
        {
            if(!_eventReservationServices.UpdateReservation(idReservation, eventReservation))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("/eventReservation/Delete/{idReservation}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEventReservation(long idReservation)
        {
            if(!_eventReservationServices.DeleteReservation(idReservation))
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}

using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinalProject.WebIII.Filters
{
    public class CheckExistingIdReservation : ActionFilterAttribute
    {
        public IEventReservationServices _eventReservationServices;
        public CheckExistingIdReservation(IEventReservationServices eventReservationServices)
        {
            _eventReservationServices = eventReservationServices;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var body = context.ActionArguments["eventReservation"] as EventReservation;

            if (_eventReservationServices.GetReservationById(body.IdReservation) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
                Console.WriteLine("Já há uma reserva com este Id.");
            }
        }
    }
}

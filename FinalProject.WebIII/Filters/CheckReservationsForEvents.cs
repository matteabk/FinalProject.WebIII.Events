using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinalProject.WebIII.Filters
{
    public class CheckReservationsForEvents :ActionFilterAttribute
    {
        public IEventReservationServices _eventReservationServices;
        public ICityEventServices _cityEventServices;
        public CheckReservationsForEvents(IEventReservationServices eventReservationServices, ICityEventServices cityEventServices)
        {
            _eventReservationServices = eventReservationServices;
            _cityEventServices = cityEventServices;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long idEvent = (long)context.ActionArguments["idEvent"];
            var cityEvent = _cityEventServices.GetEventById(idEvent);

            if (_eventReservationServices.GetReservationsByEventID(idEvent) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status204NoContent);
                Console.WriteLine("Como já havia reservas para o evento registrado, iremos apenas deixá-lo inativo.");

                _cityEventServices.UpdateStatus(idEvent, cityEvent);
            }
        }
    }
}

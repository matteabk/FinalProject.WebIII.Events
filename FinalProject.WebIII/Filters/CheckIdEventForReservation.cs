using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinalProject.WebIII.Filters
{
    public class CheckIdEventForReservation : ActionFilterAttribute
    {
        public ICityEventServices _cityEventServices;
        public CheckIdEventForReservation(ICityEventServices cityEventServices)
        {
            _cityEventServices = cityEventServices;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var body = context.ActionArguments["eventReservation"] as EventReservation;

            if(_cityEventServices.GetEventById(body.IdEvent) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
                Console.WriteLine("Não há evento com o ID apresentado.");
            }
        }

    }
}

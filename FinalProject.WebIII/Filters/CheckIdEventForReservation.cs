using FinalProject.WebIII.Core.Interfaces;
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
            long idEvent = (long)context.ActionArguments["idEvent"];

            if(_cityEventServices.GetEventById(idEvent) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
                Console.WriteLine("Não há evento com o ID apresentado.");
            }
        }

    }
}

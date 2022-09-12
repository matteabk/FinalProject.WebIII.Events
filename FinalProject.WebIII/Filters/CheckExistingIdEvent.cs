using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinalProject.WebIII.Filters
{
    public class CheckExistingIdEvent : ActionFilterAttribute
    {
        public ICityEventServices _cityEventServices;

        public CheckExistingIdEvent(ICityEventServices cityEventServices)
        {
            _cityEventServices = cityEventServices;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var body = context.ActionArguments["cityEvent"] as CityEvent;

            if (_cityEventServices.GetEventById(body.IdEvent) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
                Console.WriteLine("Já há um evento com este Id.");
            }
        }
    }
}

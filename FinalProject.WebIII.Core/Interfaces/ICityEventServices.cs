using FinalProject.WebIII.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.WebIII.Core.Interfaces
{
    public interface ICityEventServices
    {
        public List<CityEvent> GetEvents();
        public CityEvent GetEventById(long idEvent);
        public List<CityEvent> GetEventsByName(string title);
        public List<CityEvent> GetEventsByLocalAndDate(string local, DateTime dateHourEvent);
        public List<CityEvent> GetEventsByDate(DateTime dateHourEvent);
        public List<CityEvent> GetEventsByPriceRangeAndDate(decimal price1, decimal price2, DateTime dateHourEvent);
        public bool CreateEvent(CityEvent cityEvent);
        public bool UpdateEvent(long idEvent, CityEvent cityEvent);
        public void UpdateStatus(long idEvent, CityEvent cityEvent);
        public bool DeleteEvent(long idEvent);

    }
}

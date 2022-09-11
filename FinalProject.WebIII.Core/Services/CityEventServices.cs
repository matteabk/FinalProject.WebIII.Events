using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.WebIII.Core.Services
{
    public class CityEventServices : ICityEventServices
    {

        public ICityEventRepository _cityEventRepository;
        public CityEventServices(ICityEventRepository cityRepository)
        {
            _cityEventRepository = cityRepository;
        }

        public bool CreateEvent(CityEvent cityEvent)
        {
            return _cityEventRepository.CreateEvent(cityEvent);
        }

        public bool DeleteEvent(long idEvent)
        {
            return _cityEventRepository.DeleteEvent(idEvent);
        }

        public CityEvent GetEventById(long idEvent)
        {
            return _cityEventRepository.GetEventById(idEvent);
        }

        public List<CityEvent> GetEvents()
        {
            return _cityEventRepository.GetEvents();
        }

        public List<CityEvent> GetEventsByName(string title)
        {
            return _cityEventRepository.GetEventsByName(title);
        }

        public List<CityEvent> GetEventsByLocal(string local)
        {
            return _cityEventRepository.GetEventsByLocal(local);
        }

        public List<CityEvent> GetEventsByDate(DateTime dateHourEvent)
        {
            return _cityEventRepository.GetEventsByDate(dateHourEvent);
        }

        public List<CityEvent> GetEventsByPriceRange(decimal price1, decimal price2)
        {
            return _cityEventRepository.GetEventsByPriceRange(price1, price2);
        }

        public bool UpdateEvent(long idEvent, CityEvent cityEvent)
        {
            return _cityEventRepository.UpdateEvent(idEvent, cityEvent);
        }
    }
}

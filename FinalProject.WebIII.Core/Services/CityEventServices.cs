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

        public bool UpdateEvent(long idEvent, CityEvent cityEvent)
        {
            return _cityEventRepository.UpdateEvent(idEvent, cityEvent);
        }
    }
}

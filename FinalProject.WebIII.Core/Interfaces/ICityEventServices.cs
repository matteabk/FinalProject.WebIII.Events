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
        public bool CreateEvent(CityEvent cityEvent);
        public bool UpdateEvent(long idEvent, CityEvent cityEvent);
        public bool DeleteEvent(long idEvent);

    }
}

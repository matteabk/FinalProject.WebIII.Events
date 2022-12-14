using FinalProject.WebIII.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.WebIII.Core.Interfaces
{
    public interface IEventReservationServices
    {
        public List<EventReservation> GetReservations();
        public EventReservation GetReservationById(long idReservation);
        public List<EventReservation> GetReservationsByNameAndTitle(string personName, string title);
        public List<EventReservation> GetReservationsByEventID(long idEvent);
        public bool CreateReservation(EventReservation reservation);
        public bool UpdateReservation(long idReservation, int quantity);
        public bool DeleteReservation(long idReservation);

    }
}

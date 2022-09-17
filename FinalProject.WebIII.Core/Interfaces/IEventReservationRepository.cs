using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.WebIII.Core.Models;

namespace FinalProject.WebIII.Core.Interfaces
{
    public interface IEventReservationRepository
    {
        public List<EventReservation> GetReservations();
        public EventReservation GetReservationById(long id);
        public List<EventReservation> GetReservationsByNameAndTitle(string personName, string title);
        public List<EventReservation> GetReservationsByEventID(long idEvent);
        public bool CreateReservation (EventReservation reservation);
        public bool UpdateReservation (long reservationId, int quantity);
        public bool DeleteReservation (long reservationId);


    }
}

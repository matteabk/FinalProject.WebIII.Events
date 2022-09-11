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
        public bool CreateReservation(EventReservation reservation);
        public bool UpdateReservation(long idReservation, EventReservation reservation);
        public bool DeleteReservation(long idReservation);

    }
}

using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.WebIII.Core.Services
{
    public class EventReservationServices : IEventReservationServices
    {
        public IEventReservationRepository _eventReservationRepository;

        public EventReservationServices(IEventReservationRepository eventReservationRepository)
        {
            _eventReservationRepository = eventReservationRepository;
        }
        public bool CreateReservation(EventReservation reservation)
        {
            return _eventReservationRepository.CreateReservation(reservation);
        }

        public bool DeleteReservation(long idReservation)
        {
            return _eventReservationRepository.DeleteReservation(idReservation);
        }

        public EventReservation GetReservationById(long idReservation)
        {
            return _eventReservationRepository.GetReservationById(idReservation);
        }

        public List<EventReservation> GetReservations()
        {
            return _eventReservationRepository.GetReservations();
        }

        public List<EventReservation> GetReservationsByNameAndTitle(string personName, string title)
        {
            return _eventReservationRepository.GetReservationsByNameAndTitle(personName, title);
        }

        public List<EventReservation> GetReservationsByEventID(long idEvent)
        {
            return _eventReservationRepository.GetReservationsByEventID(idEvent);
        }

        public bool UpdateReservation(long idReservation, EventReservation reservation)
        {
            return _eventReservationRepository.UpdateReservation(idReservation, reservation);
        }
    }
}

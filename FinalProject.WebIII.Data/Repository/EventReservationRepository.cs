﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;

namespace FinalProject.WebIII.Data.Repository
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private readonly IConfiguration _configuration;

        public EventReservationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool CreateReservation(EventReservation reservation)
        {
            var query = "INSERT INTO EventReservation VALUES (@idEvent, @personName, @quantity)";

            var parameters = new DynamicParameters();
            parameters.Add("idEvent", reservation.IdEvent);
            parameters.Add("personName", reservation.PersonName);
            parameters.Add("quantity", reservation.Quantity);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteReservation(long idReservation)
        {
            var query = "DELETE FROM EventReservation WHERE idReservation = @idReservation";

            var parameters = new DynamicParameters();
            parameters.Add("idReservation", idReservation);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public EventReservation GetReservationById(long idReservation)
        {
            var query = "SELECT * FROM  EventReservation WHERE idReservation = @idReservation";

            var parameters = new DynamicParameters();
            parameters.Add("idReservation", idReservation);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QuerySingleOrDefault<EventReservation>(query, parameters);
        }

        public List<EventReservation> GetReservations()
        {
            var query = "SELECT * FROM  EventReservation";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<EventReservation>(query).ToList();
        }

        public bool UpdateReservation(long idReservation, EventReservation reservation)
        {
            var query = "UPDATE EventReservation SET idEvent = @idEvent, personNmae = @personName, quantity = @quantity WHERE idReservation = @idReservation";

            var parameters = new DynamicParameters();
            parameters.Add("idEvent", reservation.IdEvent);
            parameters.Add("personName", reservation.PersonName);
            parameters.Add("quantity", reservation.Quantity);
            parameters.Add("idReservation", idReservation);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }
    }
}

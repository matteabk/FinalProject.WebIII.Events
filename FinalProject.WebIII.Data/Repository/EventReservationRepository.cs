using Microsoft.Extensions.Configuration;
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

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Tivemos um erro ao se comunicar com o banco de dados, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                return false;
            }
        }

        public bool DeleteReservation(long idReservation)
        {
            var query = "DELETE FROM EventReservation WHERE idReservation = @idReservation";

            var parameters = new DynamicParameters();
            parameters.Add("idReservation", idReservation);

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Tivemos um erro ao se comunicar com o banco de dados, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                return false;
            }
        }

        public EventReservation GetReservationById(long idReservation)
        {
            var query = "SELECT * FROM  EventReservation WHERE idReservation = @idReservation";

            var parameters = new DynamicParameters();
            parameters.Add("idReservation", idReservation);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                return conn.QuerySingleOrDefault<EventReservation>(query, parameters);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Tivemos um erro ao se comunicar com o banco de dados, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                return null;
            }
        }

        public List<EventReservation> GetReservationsByEventID(long idEvent)
        {
            var query = "SELECT * FROM  EventReservation WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters();
            parameters.Add("idEvent", idEvent);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                return conn.Query<EventReservation>(query, parameters).ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Tivemos um erro ao se comunicar com o banco de dados, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                return null;
            }
        }

        public List<EventReservation> GetReservations()
        {
            var query = "SELECT * FROM  EventReservation";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<EventReservation>(query).ToList();
        }

        public List<EventReservation> GetReservationsByNameAndTitle(string personName, string title)
        {
            var query = "Select e.* FROM EventReservation e INNER JOIN CityEvent c ON e.idEvent = c.idEvent WHERE e.personName = @personName AND c.title LIKE (@title + '%')";

            var parameters = new DynamicParameters();
            parameters.Add("personName", personName);
            parameters.Add("title", title);

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                return conn.Query<EventReservation>(query, parameters).ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Tivemos um erro ao se comunicar com o banco de dados, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                return null;
            }
        }

        public bool UpdateReservation(long idReservation, int quantity) //ALTERAR PARA APENAS QUANTITY
        {
            var query = "UPDATE EventReservation SET quantity = @quantity WHERE idReservation = @idReservation";

            var parameters = new DynamicParameters();
            parameters.Add("quantity", quantity);
            parameters.Add("idReservation", idReservation);

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Tivemos um erro ao se comunicar com o banco de dados, mensagem {ex.Message}, stack trace {ex.StackTrace}");
                return false;
            }
        }
    }
}

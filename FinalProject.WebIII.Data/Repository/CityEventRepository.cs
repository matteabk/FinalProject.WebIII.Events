using Dapper;
using FinalProject.WebIII.Core.Interfaces;
using FinalProject.WebIII.Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.WebIII.Data.Repository
{
    public class CityEventRepository : ICityEventRepository
    {
        private readonly IConfiguration _configuration;

        public CityEventRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool CreateEvent(CityEvent cityEvent)
        {
            var query = "INSERT INTO CityEvent VALUES (@title, @description, @dateHourEvent, @local, @address, @price, @status)";

            var parameters = new DynamicParameters();
            parameters.Add("title", cityEvent.Title);
            parameters.Add("description", cityEvent.Description);
            parameters.Add("dateHourEvent", cityEvent.DateHourEvent);
            parameters.Add("local", cityEvent.Local);
            parameters.Add("address", cityEvent.Address);
            parameters.Add("price", cityEvent.Price);
            parameters.Add("status", cityEvent.Status);


            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteEvent(long idEvent)
        {
            var query = "DELETE FROM CityEvent WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters();
            parameters.Add("idEvent", idEvent);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public CityEvent GetEventById(long idEvent)
        {
            var query = "SELECT * FROM CityEvent WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters();
            parameters.Add("idEvent", idEvent);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QuerySingleOrDefault<CityEvent>(query, parameters);
        }

        public List<CityEvent> GetEvents()
        {
            var query = "SELECT * FROM CityEvent";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<CityEvent>(query).ToList();
        }

        public List<CityEvent> GetEventsByName(string title)
        {
            var query = "SELECT * FROM CityEvent WHERE Title LIKE (@title + '%')";

            var parameters = new DynamicParameters();
            parameters.Add("title", title);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<CityEvent>(query, parameters).ToList();
        }

        public List<CityEvent> GetEventsByLocalAndDate(string local, DateTime dateHourEvent)
        {
            var query = "SELECT * FROM CityEvent WHERE Local LIKE (@local + '%') AND CAST(dateHourEvent as DATE) = CAST(@dateHourEvent as DATE)";

            var parameters = new DynamicParameters();
            parameters.Add("local", local);
            parameters.Add("dateHourEvent", dateHourEvent);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<CityEvent>(query, parameters).ToList();
        }

        public List<CityEvent> GetEventsByDate (DateTime dateHourEvent)
        {
            var query = "SELECT * FROM CityEvent WHERE CAST(dateHourEvent as DATE) = CAST(@dateHourEvent as DATE)";

            var parameters = new DynamicParameters();
            parameters.Add("dateHourEvent", dateHourEvent);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<CityEvent>(query, parameters).ToList();
        }

        public List<CityEvent> GetEventsByPriceRangeAndDate(decimal price1, decimal price2, DateTime dateHourEvent)
        {
            var query = "SELECT * FROM CityEvent WHERE CAST(dateHourEvent as DATE) = CAST(@dateHourEvent as DATE) AND Price BETWEEN @price1 AND @price2";

            var parameters = new DynamicParameters();
            parameters.Add("price1", price1);
            parameters.Add("price2", price2);
            parameters.Add("dateHourEvent", dateHourEvent);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<CityEvent>(query,parameters).ToList();
        }

        public bool UpdateEvent(long idEvent, CityEvent cityEvent)
        {
            var query = "UPDATE CityEvent SET title = @title, description = @description, dateHourEvent = @dateHourEvent, local = @local, address = @address, price = @price, status = @status WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters();
            parameters.Add("title", cityEvent.Title);
            parameters.Add("description", cityEvent.Description);
            parameters.Add("dateHourEvent", cityEvent.DateHourEvent);
            parameters.Add("local", cityEvent.Local);
            parameters.Add("address", cityEvent.Address);
            parameters.Add("price", cityEvent.Price);
            parameters.Add("status", cityEvent.Status);
            parameters.Add("idEvent", idEvent);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public void UpdateStatus(long idEvent, CityEvent cityEvent)
        {
            var query = "UPDATE CityEvent SET status = 'false' WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters();
            parameters.Add("status", cityEvent.Status);
            parameters.Add("idEvent", cityEvent.IdEvent);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            _ = conn.Execute(query, parameters);
        }
    }
}

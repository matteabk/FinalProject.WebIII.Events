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
            var query = "INSERT INTO CityEvent VALUES (@title, @description, @dateHourEvent, @local, @address, @price)";

            var parameters = new DynamicParameters();
            parameters.Add("title", cityEvent.Title);
            parameters.Add("description", cityEvent.Description);
            parameters.Add("dateHourEvent", cityEvent.DateHourEvent);
            parameters.Add("local", cityEvent.Local);
            parameters.Add("address", cityEvent.Address);
            parameters.Add("price", cityEvent.Price);

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

        public bool UpdateEvent(long idEvent, CityEvent cityEvent)
        {
            var query = "UPDATE CityEvent SET title = @title, description = @description, dateHourEvent = @dateHourEvent, local = @local, address = @address, price = @price WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters();
            parameters.Add("title", cityEvent.Title);
            parameters.Add("description", cityEvent.Description);
            parameters.Add("dateHourEvent", cityEvent.DateHourEvent);
            parameters.Add("local", cityEvent.Local);
            parameters.Add("address", cityEvent.Address);
            parameters.Add("price", cityEvent.Price);
            parameters.Add("idEvent", idEvent);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }
    }
}

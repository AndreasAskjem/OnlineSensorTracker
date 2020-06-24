using Dapper;
using MySql.Data.MySqlClient;
using OnlineSensorTracker.Core.DomainModel;
using OnlineSensorTracker.Core.DomainServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbSensorModel = OnlineSensorTracker.Infrastructure.DataAccess.Model.SensorModel;

namespace OnlineSensorTracker.Infrastructure.DataAccess.Repository
{
    public class SensorModelRepository : ISensorModelRepository
    {

        private readonly string _connectionString =
                "Server=localhost;" +
                "Database=sensordata;" +
                "User=Andreas;" +
                "Port=3306;" +
                "Password=1234567b;";

        /*
        public SensorModelRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString.Value;
        }
        */

        public async Task<bool> Create(SensorModel submission)
        {
            await using var connection = new MySqlConnection(_connectionString);
            string sqlCode = "INSERT INTO sensordata.brightness(value)" +
                            $"VALUES({submission.Value})";
            var rowsAffected = await connection.ExecuteAsync(sqlCode, submission);
            return rowsAffected == 1;
        }
        //public async Task<bool> SendResultToDb(SensorRead result)
        //{  
        //}
        
        /*
        public void SendResultToDb(SensorRead result)
        {
            var connection = GetConnection();
            var sqlCode = "INSERT INTO sensordata.brightness(value)" +
                         //$"VALUES({result.Brightness})";
                         $"VALUES({result.Value.ToString(CultureInfo.InvariantCulture)})";
            connection.Execute(sqlCode);
        }
        */


        public async Task<IEnumerable<SensorModel>> ReadAll()
        {
            await using var connection = new MySqlConnection(_connectionString);
            const string sqlCode = "SELECT * FROM sensordata.brightness";
            IEnumerable<DbSensorModel> result = await connection.QueryAsync<DbSensorModel>(sqlCode);
            return MapToDomain(result);
        }

        private static IEnumerable<SensorModel> MapToDomain(IEnumerable<DbSensorModel> dbSensorModel)
        {
            List<SensorModel> sensorModel = new List<SensorModel>();

            dbSensorModel.ToList().ForEach(element => sensorModel.Add(new SensorModel(element.Id, element.Value)));
            return sensorModel;
        }

        /*
        private static MySqlConnection GetConnection()
        {
            var connectionString =
                "Server=localhost;" +
                "Database=sensordata;" +
                "User=Andreas;" +
                "Port=3306;" +
                "Password=1234567b;";

            return new MySqlConnection(connectionString);
        }
        */

    }
}

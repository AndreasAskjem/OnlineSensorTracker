using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineSensorTracker.Core.ApplicationService;
using OnlineSensorTracker.Core.DomainModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineSensorTracker.Controllers
{
    [Route("db")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DbService _dbService;
        //private readonly SerialService _serialService;
        public DataController(DbService dbService/*, SerialService serialService*/)
        {
            _dbService = dbService;
            //_serialService = serialService;
        }

        [HttpGet]
        public async Task<IEnumerable<SensorModel>> ReadDb()
        {
            var results = await _dbService.ReadDb();
            return results;
        }


        [HttpPost]
        public /*async*/ void SendToDb(SensorModel sensorModel)
        {
            //var sensorRead = new SensorReadModel
            //{
            //    Value = sensorReadViewModel.Value
            //};


            /*
            await _dbService.SendToDb(sensorModel);
            */


            //double result = 25.11;
            //_dbService.SendResultToDb(result);
            //SendResultToDb(result);

            //return result;
        }
  

        /*
        public class SensorReadViewModel
        {
            public int Value { get; set; }
        }

        public class DBReadViewModel
        {
            public int Id { get; set; }
            public int Value { get; set; }
        }
        */

    }
}

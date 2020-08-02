using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineSensorTracker.Core.DomainModel;
using OnlineSensorTracker.Core.DomainServices;

namespace OnlineSensorTracker.Core.ApplicationService
{
    class SerialService
    {
        private readonly ISensorSerialRepository _serialRepository;
        public SerialService(ISensorSerialRepository serialRepository)
        {
            _serialRepository = serialRepository;
        }
        public async Task<SensorModel> SendToDb(SensorModel submission)
        {
            //var submission = new SensorModel();
            await _serialRepository.Create(submission);/////////////
            return submission;

        }
    }
}

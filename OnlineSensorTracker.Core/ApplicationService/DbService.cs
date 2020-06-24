using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineSensorTracker.Core.DomainModel;
using OnlineSensorTracker.Core.DomainServices;

namespace OnlineSensorTracker.Core.ApplicationService
{
    public class DbService
    {
        private readonly ISensorModelRepository _modelRepository;
        public DbService(ISensorModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<SensorModel> SendToDb(SensorModel submission)
        {
            //var submission = new SensorModel();
            await _modelRepository.Create(submission);/////////////
            return submission;

        }

        public async Task<IEnumerable<SensorModel>> ReadDb()
        {
            //var dbModel = new SensorModel();
            return await _modelRepository.ReadAll();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineSensorTracker.Core.DomainModel;

namespace OnlineSensorTracker.Core.DomainServices
{
    public interface ISensorModelRepository
    {
        Task<bool> Create(SensorModel submission);
        Task<IEnumerable<SensorModel>> ReadAll();

    }
}

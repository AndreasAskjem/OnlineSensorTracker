using System;

namespace OnlineSensorTracker.Core.DomainModel
{
    public class SensorModel
    {
        public int? Id { get; set; }
        public int Value { get; set; }

        public SensorModel(int value) {
            Value = value;
        }

        public SensorModel(int id, int value)
        {
            Id = id;
            Value = value;
        }
    }
}

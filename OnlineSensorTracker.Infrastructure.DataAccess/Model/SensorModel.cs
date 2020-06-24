using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSensorTracker.Infrastructure.DataAccess.Model
{
    public class SensorModel
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public SensorModel()
        {
        }

        public SensorModel(int id, int value)
        {
            Id = id;
            Value = value;
        }
    }
}

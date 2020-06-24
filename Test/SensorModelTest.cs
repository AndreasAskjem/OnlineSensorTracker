using Moq;
using NUnit.Framework;
using OnlineSensorTracker.Core.DomainModel;
using OnlineSensorTracker.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class SensorModelTest
    {
        
        [Test]
        public void TestCreate()
        {
            var mock = new Mock<ISensorModelRepository>();
            //mock.Setup(repo => repo.Create(45))
            //    .Returns(Task.FromResult(true));
            //var 
        }
        
    }
}

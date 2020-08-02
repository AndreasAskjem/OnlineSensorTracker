using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using aaa = OnlineSensorTracker.Infrastructure.DataAccess.Repository.SensorModelRepository;
using OnlineSensorTracker.Core.DomainModel;
using OnlineSensorTracker.Core.DomainServices;

namespace OnlineSensorTracker.Infrastructure.DataAccess.Repository
{
    public class SerialListener : BackgroundService
    {
        private SerialConnection port;
        private readonly ISensorSerialRepository serialRepository;

        public SerialListener(ISensorSerialRepository serialRepository) {

            this.serialRepository = serialRepository;
            //serialRepository.Create();
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("AAAAAAAAAAAAAAA");
            port = new SerialConnection();
            Thread portThread = new Thread(new ThreadStart(port.SerialReader));
            // This thread keeps port.Value constantly updated.
            portThread.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    int result = port.Value;
                    await serialRepository.Create(new SensorModel(result));
                }
                catch (Exception e)
                {
                    await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
                }
            }
        }

        /*
        SerialPort port = new SerialPort
        {
            PortName = GetArduinoPort(),
            BaudRate = 9600,
            Parity = Parity.None,
            DataBits = 8,
            StopBits = StopBits.One,
            Handshake = Handshake.None,
            RtsEnable = true
        };
        */

        /*
        public override void Dispose()
        {
            if(port != null)
            {

            }
            
            
            base.Dispose();
        }
        */

        /*
        public static SerialPort MakeConnection()
        {
            SerialConnection port = new SerialConnection();
            Thread portThread = new Thread(new ThreadStart(port.SerialReader));
            // This thread keeps port.Value constantly updated.
            portThread.Start();
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine(port.Value);
            }
        }
        */
    }
}

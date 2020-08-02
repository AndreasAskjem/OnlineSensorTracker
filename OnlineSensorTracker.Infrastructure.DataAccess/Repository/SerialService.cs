using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Management;
using System.Threading;

namespace OnlineSensorTracker.Infrastructure.DataAccess.Repository
{
    public class SerialService
    {
        //static SerialPort _serialPort;
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
    }
}
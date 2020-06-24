using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Management;

namespace OnlineSensorTracker.Core.ApplicationService
{
    public class SerialService
    {
        //static SerialPort _serialPort;
        public static SerialPort MakeConnection()
        {
            SerialPort port = new SerialPort();
            port.PortName = "COM3";
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Handshake = Handshake.None;
            port.RtsEnable = true;

            port.DataReceived += new SerialDataReceivedEventHandler(DataReceiver);

            port.Open();
            Console.ReadKey();
            port.Close();

            return port;
        }

        private static void DataReceiver(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort myport = (SerialPort)sender;

            //String data = myport.ReadExisting();
            string data = myport.ReadLine();

            //char[] separator = new char[] { ',' };
            //string[] stringValues = data.Split(separator, StringSplitOptions.None);
            //string[] values = data.Split(separator, StringSplitOptions.None);
            //int[] values = Array.ConvertAll(stringValues, int.Parse);

            /*
            if (values.Length == 3)
            {
                Console.WriteLine($"First: {values[0]}, Second: {values[1]}, Third: {values[2]}");
            }
            else
            {
                Console.WriteLine($"Error.\nArray length: {values.Length}\nRaw data:\n{data}");
            }
            */

            //Console.WriteLine(data);
            //Console.WriteLine("\n");
            //Console.WriteLine(int.Parse(data)/2);

            //Thread.Sleep(1000);
            //Console.WriteLine("");
        }

        private void aaaaaaa()
        {
            //connection = makeConnectionObject ? Local function
            SerialPort port = ConnectToSerialPort();

            port.DataReceived += new SerialDataReceivedEventHandler(DataReceiver);
            port.Open();
            Console.ReadKey();
            port.Close();

            //read value

            //send value
        }
        private SerialPort ConnectToSerialPort()
        {
            SerialPort port = new SerialPort();
            port.PortName = GetArduinoPort();
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Handshake = Handshake.None;
            port.RtsEnable = true;

            return (port);

            port.DataReceived += new SerialDataReceivedEventHandler(DataReceiver);

            port.Open();
            Console.ReadKey();
            port.Close();
        }




        //Taken from https://stackoverflow.com/a/5397732/12216676
        private string GetArduinoPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                /* Do Nothing */
            }

            return null;
        }
    }
}

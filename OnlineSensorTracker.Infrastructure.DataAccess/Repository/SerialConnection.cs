﻿using System;
using System.IO.Ports;
using System.Management;

namespace OnlineSensorTracker.Infrastructure.DataAccess.Repository
{
    internal class SerialConnection
    {
        public int Value { get; private set; } = 0;
        public void SerialReader()
        {
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

            port.DataReceived += new SerialDataReceivedEventHandler(DataReceiver);

            port.Open();
            Console.ReadKey();
            port.Close();
        }

        private void DataReceiver(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort myport = (SerialPort)sender;

            string value = myport.ReadLine();

            if (int.TryParse(value, out int intValue))
            {
                Value = intValue;
            }
        }


        //Taken from https://stackoverflow.com/a/5397732/12216676
        //It looks for connected Arduino devices and returns the name of the first it finds.
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
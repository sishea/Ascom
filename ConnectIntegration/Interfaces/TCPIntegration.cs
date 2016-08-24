﻿using System;
using System.Net.Sockets;
using System.Xml.Linq;

namespace AscomIntegration
{
    public class TCPInterface : ConnectInterface
    {
        protected TcpClient _client;
        protected NetworkStream _stream;

        public TCPInterface(XElement element) : base(element) { }

        public void SendMessage(string message)
        {
            Connect();
            _numMessages++;
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            try
            {
                // Send the message to the connected TcpServer. 
                _stream.Write(data, 0, data.Length);
                _numSends++;
            }
            catch (ArgumentNullException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString(), "ArgumentNullException");
                _numFails++;
            }
            catch (SocketException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString(), "SocketException");
                _numFails++;
            }

            Close();
        }

        protected void Connect()
        {
            _client = new TcpClient();
            _client.Connect(_address, _port);
            _stream = _client.GetStream();
        }

        protected void Close()
        {
            _stream.Close();
            _client.Close();
        }
    }
}
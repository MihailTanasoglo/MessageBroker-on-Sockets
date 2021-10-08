using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MessageBroker
{
    class SenderSocket
    {
        private Socket _socket;
        public bool fConnection;

        public SenderSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Connection(string ipAddress, int port)
        {
            //Асинхронный запуск с ожиданием callback
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectedCallback, null);
            Thread.Sleep(3000);
        }

        public void Send(byte[] data)
        {
            try
            {
                _socket.Send(data);
            }
            catch(Exception e)
            {
                Console.WriteLine($" Couldn`t send data.{ e.Message}");
            }

        }



        private void ConnectedCallback(IAsyncResult asyncResult)
        {
            if (_socket.Connected)
            {
                Console.WriteLine("Отправитель подключился к брокеру сообщений.");
            }
            else
            {
                Console.WriteLine("Не удалось подключить отправителя к брокеру сообщений.");
                Console.WriteLine("Код ошибки: Stupid STUDENT");
            }

            fConnection = _socket.Connected;
        }

    }
}

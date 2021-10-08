using Common;
using Newtonsoft.Json;
using System;
using System.Text;

namespace MessageBroker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ThisIsSender");

            var senderSocket = new SenderSocket();
            senderSocket.Connection(Settings.BrokerIp, Settings.BrokerPort);

            if (senderSocket.fConnection)
            {
                for (; ;)
                {
                    var payload = new PayLoad();

                    Console.Write("Введите тему: ");
                    payload.Topic = Console.ReadLine().ToLower();

                    Console.Write("Введите текст: ");
                    payload.Message = Console.ReadLine();

                    var payloadString = JsonConvert.SerializeObject(payload);
                    byte[] data = Encoding.UTF8.GetBytes(payloadString);

                    senderSocket.Send(data);
                }
            }
                 

            Console.ReadLine();

        }
    }
}

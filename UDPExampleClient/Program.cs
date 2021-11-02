using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPExampleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client:");
            string message = Console.ReadLine();
            SendMessage(message);
        }

        public static void SendMessage(string message)
        {
            //send data to the server
            byte[] data = Encoding.UTF8.GetBytes(message);
            UdpClient socket = new UdpClient();
            socket.Send(data, data.Length, "255.255.255.255", 9999);

            //to recieve an unknown amount of messages
            while (true)
            {
                //rfeceive data from the server
                IPEndPoint from = null;
                byte[] recievedData = socket.Receive(ref from);
                string recievedString = Encoding.UTF8.GetString(recievedData);
                Console.WriteLine(recievedString);
            }
        }
    }
}

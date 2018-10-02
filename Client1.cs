using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Clients
{
    class Client1
    {
        static void Main(string[] args)
        {
            int port = 12000;
            string IpAddress = "127.0.0.1";
            Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IpAddress), port);
            ClientSocket.Connect(ep);
            Console.WriteLine("Client is connected");
            while (true)
            {
                string msgFromClient = null;
                Console.WriteLine("Enter the message");
                msgFromClient = Console.ReadLine();
                ClientSocket.Send(System.Text.Encoding.ASCII.GetBytes(msgFromClient), 0, msgFromClient.Length, SocketFlags.None);

                byte[] msgFromServer = new byte[1024];
                int size = ClientSocket.Receive(msgFromServer);
                Console.WriteLine("Server : " + System.Text.Encoding.ASCII.GetString(msgFromServer, 0, size));
            }
        }
    }
}

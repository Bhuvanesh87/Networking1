using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TplNetwork
{
    class Server1
    {
        static void Main(string[] args)
        {
            int port = 12000;
            string IpAddress="127.0.0.1";
            Socket serverlistener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IpAddress), port);
            serverlistener.Bind(ep);
            serverlistener.Listen(100);
            Console.WriteLine("The server is listening");
            Socket clientsocket = default(Socket);
            int counter=0;
            Server1 s1 = new Server1();
            while(true)
            {
                counter++;
                clientsocket = serverlistener.Accept();
                Console.WriteLine(counter + " clients connected");
                Thread UserThread = new Thread(new ThreadStart(() => s1.User(clientsocket)));
                UserThread.Start();
            }
        }
        public void User(Socket client)
        {
            while(true)
            {
                byte[] msg = new byte[1024];
                int size = client.Receive(msg);
                client.Send(msg, 0, size, SocketFlags.None);
            }

        }
    }
}

using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsteroidLesson
{
    public class Client
    {
        public Socket master;
        public string ID { get; set; }

        Action<Packet> DataManager;

        public Client() {}

        public Client(Action<Packet> dataManager)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

            this.master = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            this.DataManager = dataManager;

            try
            {
                master.Connect(remoteEP);

            }
            catch (Exception ex)
            {
                Console.WriteLine("cannot connect");
            }
            Console.WriteLine("client connected");

            Thread listenerThread = new Thread(DataIn);
            listenerThread.Start();
        }

        public void SendData(Packet packet)
        {
            master.Send(packet.ToBytes());
        }

        public void DataIn()
        {
            byte[] Buffer;
            int readBytes;

            for (; ; )
            {
                try
                {
                    Buffer = new byte[master.SendBufferSize];
                    readBytes = master.Receive(Buffer);

                    if (readBytes > 0)
                    {
                        DataManager(new Packet(Buffer));
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("The server has disconnected!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }

        
    }
}

using Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ClientData
    {
        public Socket clientSocket;
        public Thread clientThread;
        public string id;

        public ClientData()
        {
            id = Guid.NewGuid().ToString();
        }

        public ClientData(Socket clientSocket) : this()
        {
            this.clientSocket = clientSocket;
            clientThread = new Thread(Server.DataIn);
            clientThread.Start(this);
            SendRegistrationPacket();
        }

        public void SendRegistrationPacket()
        {
            GameState state = Server.GameState;
            // Point startPoint = new Point((int)state.GameArea.Width / 2, (int)state.GameArea.Width / 2);
            Point startPoint = new Point(500, 500);
            Player player = new Player(id, startPoint);
            state.AddPlayer(player);

            Packet p = new Packet(PacketType.Registration, "server");
            p.Gdata.Add(id);
            clientSocket.Send(p.ToBytes());
        }
    }
}

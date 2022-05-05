using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsteroidLesson.Logic
{
    public class AsteroidLogic : IGameModel
    {
        public event EventHandler Changed;

        public GameState GameState { get; set; }

        public List<Laser> Lasers { get; set; }

        Size area;

        public Ship Ship { get; set; }

        public AsteroidLogic()
        {
            Lasers = new List<Laser>();
            Ship = new Ship();
            GameState = new GameState();
            Client client = new Client(DataManager);
        }

        public enum Controls
        {
            Left, Right, Shoot, Forward
        }

   
        public void SetupSizes(Size area)
        {
            this.area = area;

        }

        public void SetupShipPosition(Point position)
        {
            Ship.Position = position;
        }

        public void Control(Controls control)
        {
            switch (control)
            {
                case Controls.Left:
                    Ship.Angle -= 10;
                    break;
                case Controls.Right:
                    Ship.Angle += 10;
                    break;
                case Controls.Shoot:
                    NewShoot();
                    break;
                case Controls.Forward:
                    Ship.Move();
                    break;
                default:
                    break;
            }
            Changed?.Invoke(this, null);
        }

        private void NewShoot()
        {
            double rad = (Ship.Angle - 90) * (Math.PI / 180);

            double dx = Math.Cos(rad);
            double dy = Math.Sin(rad);
            dx = dx * 8;
            dy = dy * 8;

            Lasers.Add(new Laser(new Point(Ship.Position.X + 25, Ship.Position.Y +25), new Vector(dx, dy)));
        }

        public void TimeStep()
        {
            for (int i = 0; i < Lasers.Count; i++)
            {
                bool inside = Lasers[i].Move(area);

                if (!inside)
                {
                    Lasers.RemoveAt(i);
                }
            }

            Changed?.Invoke(this, null);
        }

        public static void DataManager(Packet packet)
        {
            switch (packet.packetType)
            {
                case PacketType.Registration:
                    Console.WriteLine("Recieved a packet for registration! responding: ");
                    string id = packet.Gdata[0];
                    break;
                case PacketType.GameStateUpdate:

                    break;
            }
        }
    }
}

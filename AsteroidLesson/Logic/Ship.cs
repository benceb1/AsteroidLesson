using Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AsteroidLesson.Logic
{
    public class Ship
    {
        private double angle;
        public double Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                SetVectorFromAngle(angle);
            }
        }

        public Point Position { get; set; }
        
        public GameVector Speed { get; set; }

        public Ship()
        {
            SetVectorFromAngle(Angle);
        }

        public void SetVectorFromAngle(double Angle)
        {
            double rad = (Angle - 90) * (Math.PI / 180);

            double dx = Math.Cos(rad);
            double dy = Math.Sin(rad);
            dx = dx * 8;
            dy = dy * 8;
            Speed = new GameVector((int)dx,(int)dy);
        }

        public void Move()
        {
            // hova kerülne
            Point newCenter = new Point(Position.X + (int)Speed.X, Position.Y + (int)Speed.Y);

            Position = newCenter;
        }
    }
}

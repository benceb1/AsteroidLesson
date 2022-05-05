﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsteroidLesson.Logic
{
    public class Laser
    {
        public Point Center { get; set; }

        public Vector Speed { get; set; }

        public Laser(Point center, Vector speed)
        {
            Center = center;
            Speed = speed;
        }

        public bool Move(Size area)
        {
            // hova kerülne
            Point newCenter = new Point(Center.X + (int)Speed.X, Center.Y + (int)Speed.Y);

            if (newCenter.X >= 0 &&
                newCenter.X <= area.Width &&
                newCenter.Y >= 0 &&
                newCenter.Y <= area.Height)
            {
                Center = newCenter;
                return true;
            } else
            {
                // már a játékpályán kívülre esik
                return false;
            }
        }
    }
}
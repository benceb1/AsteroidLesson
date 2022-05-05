using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class GameVector
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GameVector(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

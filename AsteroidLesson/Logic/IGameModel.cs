using System;
using System.Collections.Generic;

namespace AsteroidLesson.Logic
{
    public interface IGameModel
    {
        
        event EventHandler Changed;
        List<Laser> Lasers { get; set; }

        public Ship Ship { get; set; }
    }
}
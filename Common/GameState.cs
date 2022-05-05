using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    public class GameState
    {
        BlockingCollection<Player> players;
        BlockingCollection<Laser> lasers;

        public Size GameArea { get; set; }

        public GameState()
        {
            players = new BlockingCollection<Player>();
            lasers = new BlockingCollection<Laser>();
            GameArea = new Size(1920, 1080);
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
    }
}

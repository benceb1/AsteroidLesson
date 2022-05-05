using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class GameState
    {

        IList<Player> players;
        IList<Laser> lasers;

        public Size GameArea { get; set; }

        public GameState()
        {
            players = new List<Player>();
            lasers = new List<Laser>();
            GameArea = new Size(1920, 1080);
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public IList<Player> Players
        {
            get
            {
                return players;
            }
        }
    }
}

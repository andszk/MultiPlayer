using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayer
{
    class GamePlayer
    {
        static void Main(string[] args)
        {
        }
                
        /// <returns>Returns winner</returns>
        public Player PlayGame<G>(IEnumerable<Player> players) where G : Game, new()
        {
            var game = new G();
            game.Players = players;
            return game.Play();
        }
    }
}

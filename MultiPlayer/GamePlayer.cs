using MultiPlayer.Games.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayer
{
    public class GamePlayer
    {
        static void Main(string[] args)
        {
            var gamePlayer = new GamePlayer();
            var players = new List<RandomPlayer<TPlayerTTT>>
            {
                new RandomPlayer<TPlayerTTT>(TPlayerTTT.O),
                new RandomPlayer<TPlayerTTT>(TPlayerTTT.X)
            };

            //TODO Ok, this is too much, GameType G, should be ehough
            gamePlayer.PlayGame<TicTacToe, TPlayerTTT>(players);
        }

        /// <returns>Returns winner</returns>
        public TPlayer? PlayGame<TGame,TPlayer>(IEnumerable<Player<TPlayer>> players) where TGame : Game<TPlayer>, new() where TPlayer : struct, Enum
        {
            var game = new TGame
            {
                Players = players
            };
            return game.Play();
        }
    }
}

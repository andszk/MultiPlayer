using MultiPlayer.Games.TicTacToe;
using MultiPlayer.PlayerAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayer
{
    public class GamePlayer
    {
        static void Main()
        {
            var gamePlayer = new GamePlayer();
            var players = new List<Player<TPlayerTTT>>
            {
                new RandomPlayer<TPlayerTTT>(TPlayerTTT.O),
                new MinMaxPlayer<TPlayerTTT, TicTacToe>(TPlayerTTT.X)
            };

            int gamesNumber = 10000;
            int xWon = 0;
            for (int i = 0; i < gamesNumber; i++)
            {
                var winner = gamePlayer.PlayGame<TicTacToe, TPlayerTTT>(players);
                if (winner == TPlayerTTT.X)
                    xWon++;
                else
                {

                }
            }
            Console.WriteLine("X win ratio " + (double)xWon/gamesNumber);
        }

        /// <returns>Returns winner</returns>
        public TPlayer? PlayGame<TGame, TPlayer>(IEnumerable<Player<TPlayer>> players) where TGame : Game<TPlayer>, new() where TPlayer : struct, Enum
        {
            var game = new TGame
            {
                Players = players
            };
            return game.Play();
        }
    }
}

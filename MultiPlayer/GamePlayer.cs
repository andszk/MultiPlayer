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
            var players = new List<Player>
            {
                new RandomPlayer((int)TTTTPlayer.O),
                new MinMaxPlayer<TicTacToe>((int)TTTTPlayer.X)
            };

            int gamesNumber = 10000;
            int xWon = 0;
            for (int i = 0; i < gamesNumber; i++)
            {
                var winner = gamePlayer.PlayGame<TicTacToe>(players);
                if (winner == (int)TTTTPlayer.X)
                    xWon++;
                else
                {

                }
            }
            Console.WriteLine("X win ratio " + (double)xWon/gamesNumber);
        }

        /// <returns>Returns winner</returns>
        public int? PlayGame<TGame>(List<Player> players)
            where TGame : Game, new()
        {
            var game = new TGame
            {
                Players = players
            };
            return game.Play(true);
        }
    }
}

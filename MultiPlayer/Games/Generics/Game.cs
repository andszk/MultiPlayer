using MultiPlayer.Games;
using MultiPlayer.Games.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiPlayer
{
    public abstract class Game
    {
        public abstract Rules Rules { get; }

        private IEnumerable<Player> _players;
        public IEnumerable<Player> Players
        {
            get { return _players;}
            set
            {
                if (value.Count() != Rules.NumberOfPlayers)
                {
                    throw new ArgumentOutOfRangeException($"Wrong number of players. Supported: {Rules.NumberOfPlayers}, passed: {value.Count()}");
                }
                else
                    _players = value;
            }
        }

        public int? Play(bool log = false)
        {
            while (!Rules.IsGameEnded)
            {
                Player player = Players.First((matchingPlayer) => matchingPlayer.Position.Equals(Rules.CurrentPlayer));
                Rules.MakeMove(player.ChooseMove(Rules.LegalMoves()));

                if (log)
                {
                    Console.WriteLine(Rules.GameState);
                    Console.WriteLine("\n");
                }
            }

            return Rules.Winner;
        }
    }
}
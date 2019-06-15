﻿using MultiPlayer.Games;
using MultiPlayer.Games.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiPlayer
{
    public abstract class Game<TPlayer> where TPlayer : struct, Enum
    {
        public abstract Rules<TPlayer> Rules { get; }

        private IEnumerable<Player<TPlayer>> _players;
        public IEnumerable<Player<TPlayer>> Players
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

        public TPlayer? Play(bool log = false)
        {
            while (!Rules.IsGameEnded)
            {
                Player<TPlayer> player = Players.First((matchingPlayer) => matchingPlayer.Position.Equals(Rules.CurrentPlayer));
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
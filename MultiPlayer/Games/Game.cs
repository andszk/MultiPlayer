using MultiPlayer.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MultiPlayer.Games.Rules;

namespace MultiPlayer
{
    public abstract class Game
    {
        public abstract Rules Rules { get; }

        public IEnumerable<Player> Players
        {
            //TODO Check properties returning
            get { return Players;}
            set
            {
                if (value.Count<Player>() != Rules.NumberOfPlayers)
                {
                    throw new ArgumentOutOfRangeException($"Wrong number of players. Supported: {Rules.NumberOfPlayers}, passed: {value.Count<Player>()}");
                }
                else
                    Players = value;
            }
       }

        public abstract void MakeMove(Move move);

        public Player Play()
        {
            while (!Rules.IsGameEnded)
            {
                MakeMove(Rules.CurrentPlayerTurn.ChooseMove());
            }

            return Rules.Winner;
        }

    }
}
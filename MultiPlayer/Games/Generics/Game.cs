using MultiPlayer.Games;
using MultiPlayer.Games.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiPlayer
{
    public abstract class Game<TPlayer> where TPlayer : struct, Enum
    {
        public abstract Rules<TPlayer> Rules { get; }
        public abstract void MakeMove(Move move);
        public abstract GameState GameState { get; set; }

        private IEnumerable<Player<TPlayer>> _players;
        public IEnumerable<Player<TPlayer>> Players
        {
            //TODO Check properties returning
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

        public TPlayer? Play()
        {
            while (!Rules.IsGameEnded)
            {
                //MakeMove(Players.First((player)=>player.Position.Equals(Rules.CurrentPlayerTurn)).ChooseMove(Rules.LegalMoves(GameState)));
                Player<TPlayer> player = Players.First((matchingPlayer) => matchingPlayer.Position.Equals(Rules.CurrentPlayerTurn));
                MakeMove(player.ChooseMove(Rules.LegalMoves(GameState)));
            }

            if (Rules.Winner.HasValue)
            {
                return Rules.Winner;
            }
            else return null;
        }
    }
}
using System;
using System.Collections.Generic;

namespace MultiPlayer.Games
{
    public abstract class Rules 
    {
        public abstract List<Move> LegalMoves(GameState gameState);
        public abstract int? CheckForWinner(GameState gameState);

        public event EventHandler GameEnded;
        public event EventHandler PlayerWins;

        private int? _winner;
        private bool _isGameEnded;

        public int? Winner
        {
            get
            {
                return _winner;
            }
            protected set
            {
                _winner = value;
                IsGameEnded = true;
            }
        }

        public bool IsGameEnded { get => _isGameEnded; protected set { _isGameEnded = value;  OnGameEnded(EventArgs.Empty); } }

        public GameState MakeMove(GameState gameState, Move move)
        {
            return move?.Execute(gameState);
        }

        protected virtual void OnGameEnded(EventArgs e)
        {
            GameEnded?.Invoke(this, e);
        }

        protected virtual void OnPlayerWins(EventArgs e)
        {
            PlayerWins?.Invoke(this, e);
        }
    }
}


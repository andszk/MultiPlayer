using System;
using System.Collections.Generic;

namespace MultiPlayer.Games
{
    public abstract class Rules<TPlayer> where TPlayer : struct, Enum
    {
        public abstract List<Type> LegalMoveTypes { get; }
        public abstract TPlayer CurrentPlayerTurn { get; }
        public abstract int NumberOfPlayers { get; }

        public abstract List<Move> LegalMoves(GameState gameState);
        public abstract void CheckForWinner(GameState gameState);

        public event EventHandler GameEnded;
        public event EventHandler PlayerWins;

        private TPlayer? _winner;
        private bool _isGameEnded;

        public TPlayer? Winner
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

        public bool IsGameEnded { get => _isGameEnded; protected set { _isGameEnded = value;  OnGameEnded(new EventArgs()); } }

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


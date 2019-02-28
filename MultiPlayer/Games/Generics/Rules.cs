using System;
using System.Collections.Generic;

namespace MultiPlayer.Games
{
    public abstract class Rules<TPlayer> where TPlayer : struct, Enum
    {
        public abstract TPlayer CurrentPlayerTurn { get; }
        public int NumberOfPlayers => Enum.GetValues(typeof(TPlayer)).Length;
        public abstract GameState GameState { get; set; }

        public abstract List<Move> LegalMoves();

        public event EventHandler GameEnded;
        public event EventHandler PlayerWins;
        public event EventHandler GameStateChanged;

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

        public bool IsGameEnded { get => _isGameEnded; protected set { _isGameEnded = value;  OnGameEnded(EventArgs.Empty); } }

        public void MakeMove(Move move)
        {
            GameState = move?.Execute(GameState);
        }

        protected virtual void OnGameEnded(EventArgs e)
        {
            GameEnded?.Invoke(this, e);
        }

        protected virtual void OnPlayerWins(EventArgs e)
        {
            PlayerWins?.Invoke(this, e);
        }

        protected virtual void OnGameStateChanged(EventArgs e)
        {
            GameStateChanged?.Invoke(this, e);
        }
    }
}


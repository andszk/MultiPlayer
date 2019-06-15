using System;
using System.Collections.Generic;

namespace MultiPlayer.Games
{
    public abstract class Rules 
    {
        public int CurrentPlayer { get; protected set; }

        public abstract int NumberOfPlayers { get; set; }
        public abstract GameState GameState { get; set; }

        public abstract List<Move> LegalMoves();
        public abstract int? CheckForWinner();

        public event EventHandler GameEnded;
        public event EventHandler PlayerWins;
        public event EventHandler GameStateChanged;

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

        public GameState MakeMove(Move move)
        {
            return GameState = move?.Execute(GameState);
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


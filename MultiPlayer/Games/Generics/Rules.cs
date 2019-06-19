using MultiPlayer.Games.Generics;
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
        public event GameStateEventHandler GameStateChanged;
        public delegate void GameStateEventHandler(GameState state);

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
        public bool IsGameEnded { get => _isGameEnded; protected set { _isGameEnded = value; OnGameEnded(EventArgs.Empty); } }

        public Rules()
        {
            GameStateChanged += HandleGameStateChanged;
        }

        public void MakeMove(GameState gameState, Move move)
        {
            if (LegalMoves(gameState).Contains(move))
            {
                move?.Execute(gameState);
                OnGameStateChanged(gameState);
            }
            else
            {
                throw new IllegalMoveException();
            }
        }

        protected virtual void OnGameEnded(EventArgs e)
        {
            GameEnded?.Invoke(this, e);
        }

        protected virtual void OnPlayerWins(EventArgs e)
        {
            PlayerWins?.Invoke(this, e);
        }

        protected virtual void OnGameStateChanged(GameState e)
        {
            GameStateChanged?.Invoke(e);
        }

        public void HandleGameStateChanged(GameState state)
        {
            CheckForWinner(state);
            state.NextPlayer();
        }
    }
}


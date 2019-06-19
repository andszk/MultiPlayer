using MultiPlayer.Games.Generics;
using System;

namespace MultiPlayer.Games.TicTacToe
{
    public class TTTGameState : GameState, IBoardGame<TicTacToeBoard>
    {
        public override int NumberOfPlayers { get => Enum.GetValues(typeof(TTTTPlayer)).Length; }

        public event GameStateEventHandler GameStateChanged;
        public delegate void GameStateEventHandler(GameState state);

        private TicTacToeBoard _board;
        public TicTacToeBoard Board
        {
            get
            {
                return _board;
            }
            set
            {
                _board = value;
                OnGameStateChanged(this);
            }
        }

        public TTTGameState()
        {
            _board = new TicTacToeBoard();
        }

        public override string ToString()
        {
            return Board.ToString();
        }       

        public override object Clone()
        {
            var other = new TTTGameState
            {
                CurrentPlayer = this.CurrentPlayer
            };
            Array.Copy(this.Board.board, other.Board.board, this.Board.board.Length);
            
            return other;
        }

        public override void NextPlayer()
        {
            CurrentPlayer = (CurrentPlayer + 1) % NumberOfPlayers;
        }

        protected virtual void OnGameStateChanged(GameState e)
        {
            GameStateChanged?.Invoke(e);
        }
    }
}

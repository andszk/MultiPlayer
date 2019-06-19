using MultiPlayer.Games.Generics;
using System;

namespace MultiPlayer.Games.TicTacToe
{
    public class TTTGameState : GameState, IBoardGame<TicTacToeBoard>
    {
        public override int NumberOfPlayers { get => Enum.GetValues(typeof(TTTTPlayer)).Length; protected set => throw new AccessViolationException("Can't set number of players"); }

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
        
        public event EventHandler GameStateChanged;

        public virtual void OnGameStateChanged(EventArgs e)
        {
            GameStateChanged?.Invoke(this, e);
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
    }
}

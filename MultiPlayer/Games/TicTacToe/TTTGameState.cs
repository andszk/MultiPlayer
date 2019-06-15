using MultiPlayer.Games.Generics;
using System;

namespace MultiPlayer.Games.TicTacToe
{
    public class TTTGameState : GameState, IBoardGame<TicTacToeBoard>
    {
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
                //OnGameStateChanged(EventArgs.Empty);
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
    }
}

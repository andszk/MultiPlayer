using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayer.Games.TicTacToe
{
    public enum TTTTPlayer
    {
        O,
        X
    }

    public class TicTacToeRules : Rules
    {
        public override GameState GameState
        {
            get { return Board; }
            set
            {
                Board = value as TicTacToeBoard;
                OnGameStateChanged(EventArgs.Empty);
            }
        }

        
        private TicTacToeBoard Board { get; set; } = new TicTacToeBoard();
        public override int NumberOfPlayers { get => Enum.GetValues(typeof(TTTTPlayer)).Length ; set => throw new AccessViolationException("Can't set number of players"); }

        public TicTacToeRules()
        {
            CurrentPlayer = new Random().Next(NumberOfPlayers);
            GameStateChanged += new EventHandler(TicTacToeRules_GameStateChanged);
        }

        public override List<Move> LegalMoves()
        {
            List<Move> legalMoves = new List<Move>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board.board[i, j] == null)
                    {
                        legalMoves.Add(new Mark(i, j, (Field)CurrentPlayer));
                    }
                }
            }

            if(legalMoves.Count == 0)
            {
                IsGameEnded = true;
            }

            return legalMoves;
        }

        protected void ChangePlayerTurn()
        {
            CurrentPlayer = (CurrentPlayer + 1) % NumberOfPlayers;
        }

        public override int? CheckForWinner()
        {
            CheckRows();
            CheckColumns();
            CheckDiagonals();

            if(LegalMoves().Count == 0)
            {
                IsGameEnded = true;
            }

            return this.Winner;
        }

        private void CheckDiagonals()
        {
            if (Board.board[0, 0] == Board.board[1, 1] && Board.board[0, 0] == Board.board[2, 2] && Board.board[0, 0] != null)
                Winner = (int)(TTTTPlayer)Board.board[1, 1];
            if (Board.board[0, 2] == Board.board[1, 1] && Board.board[0, 2] == Board.board[2, 0] && Board.board[0, 2] != null)
                Winner = (int)(TTTTPlayer)Board.board[1, 1];
        }

        private void CheckColumns()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board.board[0, i] == Board.board[1, i] && Board.board[0, i] == Board.board[2, i] && Board.board[0, i] != null)
                    Winner = (int)(TTTTPlayer)Board.board[0, i];
            }
        }

        private void CheckRows()
        {
            for(int i = 0; i < 3; i++)
            {
                if (Board.board[i, 0] == Board.board[i, 1] && Board.board[i, 0] == Board.board[i, 2] && Board.board[i, 0] != null)
                    Winner = (int)(TTTTPlayer)Board.board[i, 0];
            }
        }

        private void TicTacToeRules_GameStateChanged(object sender, EventArgs e)
        {
            CheckForWinner();
            ChangePlayerTurn();
        }
    }
}

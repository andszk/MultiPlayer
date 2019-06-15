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
        public override int NumberOfPlayers { get => Enum.GetValues(typeof(TTTTPlayer)).Length ; set => throw new AccessViolationException("Can't set number of players"); }

        public override List<Move> LegalMoves(GameState gameState)
        {
            return LegalMoves(gameState as TTTGameState);
        }

        public List<Move> LegalMoves(TTTGameState gameState)
        {
            List<Move> legalMoves = new List<Move>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameState.Board.board[i, j] == null)
                    {
                        legalMoves.Add(new Mark(i, j, (Field)gameState.CurrentPlayer));
                    }
                }
            }

            if(legalMoves.Count == 0)
            {
                IsGameEnded = true;
            }

            return legalMoves;
        }

        public override int? CheckForWinner(GameState gameState)
        {
            CheckRows(gameState as TTTGameState);
            CheckColumns(gameState as TTTGameState);
            CheckDiagonals(gameState as TTTGameState);

            if(LegalMoves(gameState as TTTGameState).Count == 0)
            {
                IsGameEnded = true;
            }

            return this.Winner;
        }

        private void CheckDiagonals(TTTGameState gameState)
        {
            if (gameState.Board.board[0, 0] == gameState.Board.board[1, 1] && gameState.Board.board[0, 0] == gameState.Board.board[2, 2] && gameState.Board.board[0, 0] != null)
                Winner = (int)(TTTTPlayer)gameState.Board.board[1, 1];
            if (gameState.Board.board[0, 2] == gameState.Board.board[1, 1] && gameState.Board.board[0, 2] == gameState.Board.board[2, 0] && gameState.Board.board[0, 2] != null)
                Winner = (int)(TTTTPlayer)gameState.Board.board[1, 1];
        }

        private void CheckColumns(TTTGameState gameState)
        {
            for (int i = 0; i < 3; i++)
            {
                if (gameState.Board.board[0, i] == gameState.Board.board[1, i] && gameState.Board.board[0, i] == gameState.Board.board[2, i] && gameState.Board.board[0, i] != null)
                    Winner = (int)(TTTTPlayer)gameState.Board.board[0, i];
            }
        }

        private void CheckRows(TTTGameState gameState)
        {
            for(int i = 0; i < 3; i++)
            {
                if (gameState.Board.board[i, 0] == gameState.Board.board[i, 1] && gameState.Board.board[i, 0] == gameState.Board.board[i, 2] && gameState.Board.board[i, 0] != null)
                    Winner = (int)(TTTTPlayer)gameState.Board.board[i, 0];
            }
        }
    }
}

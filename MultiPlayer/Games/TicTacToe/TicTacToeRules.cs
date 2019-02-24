using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayer.Games.TicTacToe
{
    public enum TPlayerTTT
    {
        X,
        O
    }

    public class TicTacToeRules : Rules<TPlayerTTT>
    {
        public override int NumberOfPlayers => 2;
        public override List<Type> LegalMoveTypes { get; } = new List<Type> { typeof(Mark) };
        public override TPlayerTTT CurrentPlayerTurn => currentPlayer;

        private TPlayerTTT currentPlayer;

        public class Mark : Move
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Field Marking { get; set; }

            public Mark(int x, int y, Field marking)
            {
                X = x;
                Y = y;
                Marking = marking;
            }
        }

        //TODO make this private. Or Add some event on endturn to fire this.
        public void ChangePlayerTurn()
        {
            //TODO find a way to iterate over enums
            switch (currentPlayer)
            {
                case TPlayerTTT.O:
                    currentPlayer = TPlayerTTT.X;
                    break;
                case TPlayerTTT.X:
                    currentPlayer = TPlayerTTT.O;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override List<Move> LegalMoves(GameState gameState)
        {
            //TODO is this casting really neccesary?
            var board = gameState as TicTacToeBoard;
            List<Move> legalMoves = new List<Move>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.board[i, j] == Field.Empty)
                    {
                        Field mark;
                        switch (currentPlayer)
                        {
                            case TPlayerTTT.O:
                                mark = Field.O;
                                break;
                            case TPlayerTTT.X:
                                mark = Field.X;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        legalMoves.Add(new Mark(i, j, mark));
                    }
                }
            }

            if(legalMoves.Count == 0)
            {
                IsGameEnded = true;
            }

            return legalMoves;
        }

        public override void CheckForWinner(GameState gameState)
        {
            TicTacToeBoard board = (TicTacToeBoard)gameState;
            if (CheckRows(board) || CheckColumns(board) || CheckDiagonals(board))
            {
                Winner = currentPlayer;
            }

            if(LegalMoves(gameState).Count == 0)
            {
                IsGameEnded = true;
            }
        }

        private bool CheckDiagonals(TicTacToeBoard b)
        {
            if (b.board[0, 0] == b.board[1, 1] && b.board[0, 0] == b.board[2, 2] && b.board[0, 0] != Field.Empty)
                return true;
            if (b.board[0, 2] == b.board[1, 1] && b.board[0, 2] == b.board[2, 0] && b.board[0, 2] != Field.Empty)
                return true;
            return false;
        }

        private bool CheckColumns(TicTacToeBoard b)
        {
            for (int i = 0; i < 3; i++)
            {
                if (b.board[0, i] == b.board[1, i] && b.board[0, i] == b.board[2, i] && b.board[0, i] != Field.Empty)
                    return true;
            }
            return false;
        }

        private bool CheckRows(TicTacToeBoard b)
        {
            for(int i = 0; i < 3; i++)
            {
                if (b.board[i, 0] == b.board[i, 1] && b.board[i, 0] == b.board[i, 2] && b.board[i, 0] != Field.Empty)
                    return true;
            }
            return false;
        }
    }
}

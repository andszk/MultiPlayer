using System;

namespace MultiPlayer.Games.TicTacToe
{
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

        public override void Execute(GameState gameState)
        {
            (gameState as TTTGameState).Board.board[X,Y] = Marking;
        }

        public override bool Equals(Move other)
        {
            var mark = other as Mark;
            return mark.Marking == Marking && mark.X == X && mark.Y == Y;
        }
    }
}

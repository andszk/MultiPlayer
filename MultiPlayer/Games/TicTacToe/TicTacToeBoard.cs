using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayer.Games.TicTacToe
{
    class TicTacToeBoard: Board
    {
        public Field[,] board = new Field [3,3];

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine($"{board[0,0].ToString()}|{board[0, 1].ToString()}|{board[0, 2].ToString()}");
            s.AppendLine("-----");
            s.AppendLine($"{board[1, 0].ToString()}|{board[1, 1].ToString()}|{board[1, 2].ToString()}");
            s.AppendLine("-----");
            s.AppendLine($"{board[2, 0].ToString()}|{board[2, 1].ToString()}|{board[2, 2].ToString()}");

            s.Replace("Empty", " ");
            return s.ToString();
        }
    }

    public enum Field
    {
        Empty,
        X,
        O
    }
}

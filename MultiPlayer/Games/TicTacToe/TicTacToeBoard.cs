using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayer.Games.TicTacToe
{
    public class TicTacToeBoard: Board
    {
        public Field?[,] board;

        public TicTacToeBoard()
        {
            board = new Field?[3, 3];           
        }

        public override string ToString()
        {
            var rows = new string[3];
            for(int i=0;i<3;i++)
            {
                string[] tmp = new string[3];
                for (int j = 0; j < 3; j++)
                {
                    tmp[j] = ToPrintableString(i, j);
                }
                rows[i] = string.Join("|", tmp) + "\n";
            }

            return string.Join("-----\n",rows);
        }

        private string ToPrintableString(int x, int y)
        {
            return board[x, y].HasValue ? board[x, y].ToString() : " ";
        }
    }

    public enum Field
    {
        O,
        X,
    }
}

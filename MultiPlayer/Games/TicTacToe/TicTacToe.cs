using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultiPlayer.Games;
using MultiPlayer.Games.TicTacToe;
using static MultiPlayer.Games.TicTacToe.TicTacToeRules;

namespace MultiPlayer
{
    public class TicTacToe : Game<TPlayerTTT>, IBoardGame
    {
        public Board BoardState { get; set; } = new TicTacToeBoard();
        public override GameState GameState { get => BoardState; set => BoardState = (Board)value; }

        public override Rules<TPlayerTTT> Rules { get; } = new TicTacToeRules();
        public override void MakeMove(Move move)
        {
            //TODO check some other way to enshure typeof Mark here, as its only legal move
            var moveMark = (Mark)move;
            //TODO again
            (GameState as TicTacToeBoard).board[moveMark.X, moveMark.Y] = moveMark.Marking;

            Console.Write(GameState);
            Console.WriteLine("");

            Rules.CheckForWinner(BoardState);

            //TODO UGHHhhhhh
            (Rules as TicTacToeRules).ChangePlayerTurn();
               
        }
    }
}
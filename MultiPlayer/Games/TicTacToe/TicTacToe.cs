using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultiPlayer.Games;

namespace MultiPlayer
{
    public class TicTacToe : Game, BoardGame
    {
        public Board Board { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override Rules Rules => throw new NotImplementedException();

        public override void MakeMove(Move move)
        {
            throw new NotImplementedException();
        }
    }
}
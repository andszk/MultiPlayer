using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultiPlayer.Games;
using MultiPlayer.Games.TicTacToe;
using static MultiPlayer.Games.TicTacToe.TicTacToeRules;

namespace MultiPlayer.Games.TicTacToe
{
    public class TicTacToe : Game
    {
        public override Rules Rules { get; } = new TicTacToeRules();
    }
}
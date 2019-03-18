using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlayer.Games.TicTacToe;
using Xunit;

namespace MultiPlayer.Tests
{
    [TestClass()]
    public class GamePlayerTests
    {
        [Fact]
        public void GamePlayerTicTacToeTest()
        {
            var gamePlayer = new GamePlayer();
            var players = new List<RandomPlayer<TPlayerTTT>>
            {
                new RandomPlayer<TPlayerTTT>(TPlayerTTT.O),
                new RandomPlayer<TPlayerTTT>(TPlayerTTT.X)
            };

            gamePlayer.PlayGame<TicTacToe, TPlayerTTT>(players);
        }
    }
}
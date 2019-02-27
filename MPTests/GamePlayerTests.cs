using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlayer.Games.TicTacToe;

namespace MultiPlayer.Tests
{
    [TestClass()]
    public class GamePlayerTests
    {
        [TestMethod()]
        public void GamePlayerTicTacToeTest()
        {
            var gamePlayer = new GamePlayer();
            var players = new List<RandomPlayer<TPlayerTTT>>
            {
                new RandomPlayer<TPlayerTTT>(TPlayerTTT.O),
                new RandomPlayer<TPlayerTTT>(TPlayerTTT.X)
            };

            //TODO Ok, this is too much, GameType G, should be ehough
            gamePlayer.PlayGame<TicTacToe, TPlayerTTT>(players);
        }
    }
}
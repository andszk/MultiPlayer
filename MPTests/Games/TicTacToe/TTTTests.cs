using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlayer.Games.TicTacToe;
using static MultiPlayer.Games.TicTacToe.TicTacToeRules;

namespace MultiPlayer.Tests
{
    [TestClass()]
    public class TTTTests
    {
        [TestMethod()]
        public void TicTacToeTest()
        {
            var gamePlayer = new GamePlayer();
            var players = new List<RandomPlayer<TPlayerTTT>>
            {
                new RandomPlayer<TPlayerTTT>(TPlayerTTT.O),
                new RandomPlayer<TPlayerTTT>(TPlayerTTT.X)
            };

            gamePlayer.PlayGame<TicTacToe, TPlayerTTT>(players);
        }

        [TestMethod()]
        public void WinningConditionsRow()
        {
            var rules = new TicTacToeRules();
            var markTable = new Field[] { Field.O, Field.X };

            foreach (var mark in markTable)
            {
                for (int i = 0; i < 3; i++)
                {
                    var board = new TicTacToeBoard();
                    for (int j = 0; j < 3; j++)
                    {
                        board.board[i, j] = mark;
                    }

                    rules.GameState = board;
                    Assert.AreEqual((TPlayerTTT)mark, rules.Winner);
                }
            }
        }

        [TestMethod()]
        public void WinningConditionsColumns()
        {
            var rules = new TicTacToeRules();
            var markTable = new Field[] { Field.O, Field.X };

            foreach (var mark in markTable)
            {
                for (int i = 0; i < 3; i++)
                {
                    var board = new TicTacToeBoard();
                    for (int j = 0; j < 3; j++)
                    {
                        board.board[j, i] = mark;
                    }
                    rules.GameState = board;
                    Assert.AreEqual((TPlayerTTT)mark, rules.Winner);
                }
            }
        }

        [TestMethod()]
        public void WinningConditionsDiagonals()
        {
            var rules = new TicTacToeRules();
            var markTable = new Field[] { Field.O, Field.X };

            foreach (var mark in markTable)
            {
                var board = new TicTacToeBoard();
                board.board[0, 0] = board.board[1, 1] = board.board[2, 2] = mark;
                rules.GameState = board;
                Assert.AreEqual((TPlayerTTT)mark, rules.Winner);

                board = new TicTacToeBoard();
                board.board[0, 2] = board.board[1, 1] = board.board[2, 0] = mark;
                rules.GameState = board;
                Assert.AreEqual((TPlayerTTT)mark, rules.Winner);
            }
        }

        [TestMethod()]
        public void NoWinner()
        {
            var rules = new TicTacToeRules();
            var board = new TicTacToeBoard
            {
                board = new Field?[3, 3]{
                { Field.X, Field.O, Field.X },
                { Field.O, Field.X, Field.O },
                { Field.O, Field.X, Field.O }
            }
            };

            rules.GameState = board;
            Assert.AreEqual(0,rules.LegalMoves().Count);
            Assert.AreEqual(true, rules.IsGameEnded);
            Assert.AreEqual(null, rules.Winner);
        }
    }
}
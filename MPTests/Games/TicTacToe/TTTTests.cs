using MultiPlayer.Games.TicTacToe;
using System.Collections.Generic;
using System;
using Xunit;

namespace MultiPlayer.Tests
{
    public class TTTTests
    {
        [Fact]
        public void TicTacToeTest()
        {
            var gamePlayer = new GamePlayer();
            var players = new List<Player>
            {
                new RandomPlayer((int)TTTTPlayer.O),
                new RandomPlayer((int)TTTTPlayer.X)
            };

            gamePlayer.PlayGame<TicTacToe>(players);
        }

        [Fact]
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
                    Assert.Equal((int)mark, rules.Winner);
                }
            }
        }

        [Fact]
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
                    Assert.Equal((int)mark, rules.Winner);
                }
            }
        }

        [Fact]
        public void WinningConditionsDiagonals()
        {
            var rules = new TicTacToeRules();
            var markTable = new Field[] { Field.O, Field.X };

            foreach (var mark in markTable)
            {
                var board = new TicTacToeBoard();
                board.board[0, 0] = board.board[1, 1] = board.board[2, 2] = mark;
                rules.GameState = board;
                Assert.Equal((int)mark, rules.Winner);

                board = new TicTacToeBoard();
                board.board[0, 2] = board.board[1, 1] = board.board[2, 0] = mark;
                rules.GameState = board;
                Assert.Equal((int)mark, rules.Winner);
            }
        }

        [Fact]
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
            Assert.Empty(rules.LegalMoves());
            Assert.True(rules.IsGameEnded);
            Assert.Null(rules.Winner);
        }
    }
}
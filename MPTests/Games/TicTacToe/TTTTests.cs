using System.Collections.Generic;
using System;
using Xunit;
using MultiPlayer;
using MultiPlayer.Games.TicTacToe;

namespace MPTests.Games
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
            var game = new TicTacToe();
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

                    (game.GameState as TTTGameState).Board = board;
                    game.Rules.CheckForWinner(game.GameState);
                    Assert.Equal((int)mark, game.Rules.Winner);
                }
            }
        }

        [Fact]
        public void WinningConditionsColumns()
        {
            var game = new TicTacToe();
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
                    (game.GameState as TTTGameState).Board = board;
                    game.Rules.CheckForWinner(game.GameState);
                    Assert.Equal((int)mark, game.Rules.Winner);
                }
            }
        }

        [Fact]
        public void WinningConditionsDiagonals()
        {
            var game = new TicTacToe();

            var markTable = new Field[] { Field.O, Field.X };

            foreach (var mark in markTable)
            {
                var board = new TicTacToeBoard();
                board.board[0, 0] = board.board[1, 1] = board.board[2, 2] = mark;
                (game.GameState as TTTGameState).Board = board;
                game.Rules.CheckForWinner(game.GameState);
                Assert.Equal((int)mark, game.Rules.Winner);

                board = new TicTacToeBoard();
                board.board[0, 2] = board.board[1, 1] = board.board[2, 0] = mark;
                (game.GameState as TTTGameState).Board = board;
                game.Rules.CheckForWinner(game.GameState);
                Assert.Equal((int)mark, game.Rules.Winner);
            }
        }

        [Fact]
        public void NoWinner()
        {
            var game = new TicTacToe();
            var board = new TicTacToeBoard
            {
                board = new Field?[3, 3]{
                { Field.X, Field.O, Field.X },
                { Field.O, Field.X, Field.O },
                { Field.O, Field.X, Field.O }
            }
            };

            (game.GameState as TTTGameState).Board = board;
            game.Rules.CheckForWinner(game.GameState);
            Assert.Empty(game.Rules.LegalMoves(game.GameState));
            Assert.True(game.Rules.IsGameEnded);
            Assert.Null(game.Rules.Winner);
        }
    }
}
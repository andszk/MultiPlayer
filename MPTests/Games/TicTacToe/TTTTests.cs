using System.Collections.Generic;
using System;
using Xunit;
using MultiPlayer;
using MultiPlayer.Games.TicTacToe;
using System.Linq;
using MultiPlayer.PlayerAgents;

namespace MPTests.Games
{
    public class TTTTests
    {
        [Fact]
        public void TicTacToeTest()
        {
            var players = new List<Player>
            {
                new RandomPlayer((int)TTTTPlayer.O),
                new RandomPlayer((int)TTTTPlayer.X)
            };
            var game = new TicTacToe() { Players = players };
            game.Play();
            CheckGameBalance(game);
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

        [Fact]
        public void NotLoosingWithRandomPlayerTTT()
        {
            var players = new List<Player>
            {
                new RandomPlayer((int)TTTTPlayer.O),
                new MinMaxPlayer<TicTacToe>((int)TTTTPlayer.X)
            };

            int gamesNumber = 100000;
            int xWon = 0;
            int oWon = 0;
            int draw = 0;

            for (int i = 0; i < gamesNumber; i++)
            {
                var game = new TicTacToe() { Players = players };
                var winner = game.Play();
                CheckGameBalance(game);

                switch (winner)
                {
                    case null:
                        draw++;
                        break;
                    case (int)TTTTPlayer.O:
                        oWon++;
                        break;
                    case (int)TTTTPlayer.X:
                        xWon++;
                        break;
                }
            }

            Assert.Equal(0, oWon);
            Assert.True(xWon > draw);
        }

        [Fact]
        public void TwoMinMaxPlayersAlwaysDraw()
        {
            var players = new List<Player>
            {
                new MinMaxPlayer<TicTacToe>((int)TTTTPlayer.O),
                new MinMaxPlayer<TicTacToe>((int)TTTTPlayer.X)
            };

            int gamesNumber = 10000;
            int xWon = 0;
            int oWon = 0;
            int draw = 0;

            for (int i = 0; i < gamesNumber; i++)
            {
                var game = new TicTacToe() { Players = players };
                var winner = game.Play();
                CheckGameBalance(game);

                switch (winner)
                {
                    case null:
                        draw++;
                        break;
                    case (int)TTTTPlayer.O:
                        oWon++;
                        break;
                    case (int)TTTTPlayer.X:
                        xWon++;
                        break;
                }
            }
            Console.WriteLine($"X won: {xWon}, O won: {oWon}, draw: {draw}");

            Assert.Equal(0, oWon);
            Assert.Equal(0, xWon);
            Assert.Equal(gamesNumber, draw);
        }

        protected void CheckGameBalance(Game game)
        {

            var endGameState = (game.GameState as TTTGameState).Board.ToString();
            int xMarks = endGameState.Count(letter => letter == 'X');
            int oMarks = endGameState.Count(letter => letter == 'O');

            Assert.True(xMarks > 2);
            Assert.True(oMarks > 2);
            switch (game.Rules.Winner)
            {
                case null:
                    Assert.True(Math.Abs(xMarks - oMarks) <= 1);
                    break;
                case (int)TTTTPlayer.O:
                    Assert.Equal(1, oMarks - xMarks);
                    break;
                case (int)TTTTPlayer.X:
                    Assert.Equal(1, xMarks - oMarks);
                    break;
            }
        }
    }
}
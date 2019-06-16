using MultiPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlayer.Games.TicTacToe;
using Xunit;

namespace MPTests.GamePlayerTests
{
    public class GamePlayerTests
    {
        [Fact]
        public void GamePlayerTicTacToeTest()
        {
            var gamePlayer = new GamePlayer();
            var players = new List<Player>
            {
                new RandomPlayer((int)TTTTPlayer.O),
                new RandomPlayer((int)TTTTPlayer.X)
            };

            gamePlayer.PlayGame<TicTacToe>(players);
        }
    }
}
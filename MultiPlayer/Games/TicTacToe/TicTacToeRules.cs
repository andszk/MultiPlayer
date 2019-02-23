using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayer.Games.TicTacToe
{
    class TicTacToeRules : Rules
    {
        public override int NumberOfPlayers => 2;

        protected override void OnEndGameEvent(EndGameEventEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

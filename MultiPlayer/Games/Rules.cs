using System;
using System.Collections.Generic;

namespace MultiPlayer.Games
{
    public abstract class Rules
    {
        public event EventHandler<EndGameEventEventArgs> EndGame ;

        public Player Winner { get; private set; }
        public IEnumerable<Move> LegalMoves { get; set; }
        public Player CurrentPlayerTurn { get; }
        public bool IsGameEnded { get; internal set; }
        public abstract int NumberOfPlayers { get; }

        protected abstract void OnEndGameEvent(EndGameEventEventArgs e);

        public Rules()
        {
            EndGame += Rules_EndGameEvent;
        }

        public class EndGameEventEventArgs : EventArgs
        {
            //Currently unrelevant, can use empty EventArgs instead
            public Player Winner { get; set; }
        }

        protected virtual void OnEndGame(EndGameEventEventArgs e)
        {
            EndGame?.Invoke(this, e);
        }

        private void DetermineWinner()
        {
            throw new NotImplementedException();
        }

        private void Rules_EndGameEvent(object sender, EndGameEventEventArgs e)
        {
            DetermineWinner();
            IsGameEnded = true;
        }
    }
}


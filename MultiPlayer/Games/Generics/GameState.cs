using System;
using System.Runtime.Serialization;

namespace MultiPlayer.Games
{
    public abstract class GameState : ICloneable
    {
        public int CurrentPlayer { get; protected set; }  
        public abstract int NumberOfPlayers { get; protected set; }

        public abstract void NextPlayer();
        public abstract object Clone();
        public abstract override string ToString();

        internal void ChooseFirstPlayer()
        {
            CurrentPlayer = new Random().Next(NumberOfPlayers);
        }
    }
}
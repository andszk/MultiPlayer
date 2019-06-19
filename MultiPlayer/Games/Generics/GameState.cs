using System;
using System.Runtime.Serialization;

namespace MultiPlayer.Games
{
    public abstract class GameState : ICloneable
    {
        public int CurrentPlayer { get; set; }  
        public abstract int NumberOfPlayers { get; }

        public abstract void NextPlayer();
        public abstract object Clone();
        public abstract override string ToString();

        //TODO move to Rules?
        public void ChooseFirstPlayer()
        {
            //CurrentPlayer = new Random().Next(NumberOfPlayers);
        }
    }
}
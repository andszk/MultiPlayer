using System;

namespace MultiPlayer.Games
{
    public abstract class GameState
    {
        public int CurrentPlayer { get; set; }
        
        public abstract override string ToString();
    }
}
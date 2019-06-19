using MultiPlayer.Games;
using System;

namespace MultiPlayer
{
    public abstract class Move : IEquatable<Move>
    {
        public abstract bool Equals(Move other);
        public abstract void Execute(GameState gameState);
    }
}
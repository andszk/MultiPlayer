using System;
using System.Collections.Generic;

namespace MultiPlayer
{
    public abstract class Player
    {
        public abstract Move ChooseMove(List<Move> legalMoves);
        public virtual string Name { get; set; }
        public virtual int Position { get;}

        protected Player(int position)
        {
            Position = position;
        }
    }
}
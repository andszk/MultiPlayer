using System;
using System.Collections.Generic;

namespace MultiPlayer
{
    public abstract class Player<TPlayerPosition>
    {
        public abstract Move ChooseMove(List<Move> legalMoves);
        public virtual string Name { get; set; }
        public virtual TPlayerPosition Position { get;}

        public Player(TPlayerPosition position)
        {
            Position = position;
        }
    }
}
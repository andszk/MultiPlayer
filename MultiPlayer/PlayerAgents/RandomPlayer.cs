using System;
using System.Collections.Generic;

namespace MultiPlayer
{
    public class RandomPlayer<T> : Player<T> where T : Enum
    {
        public RandomPlayer(T position):base(position)
        {
        }

        public override string Name { get; set; } = "Random Player";

        public override Move ChooseMove(List<Move> legalMoves)
        {
            Random random = new Random();
            return legalMoves?[random.Next(legalMoves.Count)];
        }
    }
}
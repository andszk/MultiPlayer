using MultiPlayer.Games;
using System;
using System.Collections.Generic;

namespace MultiPlayer
{
    public class RandomPlayer : Player
    {
        public RandomPlayer(int position) : base(position)
        {
        }

        public override string Name { get; set; } = "Random Player";

        public override Move ChooseMove(GameState gameState, List<Move> legalMoves)
        {
            Random random = new Random();
            return legalMoves?[random.Next(legalMoves.Count)];
        }
    }
}
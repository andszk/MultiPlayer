using MultiPlayer.Games;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiPlayer.PlayerAgents
{
    public class MinMaxPlayer<TPlayer, TGame> : Player<TPlayer> where TPlayer : struct, Enum where TGame : Game<TPlayer>, new()
    {
        protected Rules<TPlayer> Rules;

        public MinMaxPlayer(TPlayer position) : base(position)
        {
            this.Rules = new TGame().Rules;
        }

        public override string Name { get; set; } = "Min Max Player";

        public override Move ChooseMove(List<Move> legalMoves)
        {
            List<KeyValuePair<int, Move>> points = new List<KeyValuePair<int, Move>>();
            foreach (Move move in legalMoves)
            {
                points.Add(new KeyValuePair<int, Move>(MinMax(Rules.MakeMove(move), 10, true), move));
            }
            return points.First(point => point.Key == 1).Value;
        }

        private int MinMax(GameState gameState, int depth, bool maximazing)
        {
            Rules.GameState = gameState;

            if (depth == 0 || Rules.LegalMoves().Count == 0)
            {
                return EvaluateBoard(gameState);
            }

            List<KeyValuePair<int, Move>> points = new List<KeyValuePair<int, Move>>();
            foreach (var move in Rules.LegalMoves())
            {
                Rules.GameState = gameState;
                points.Add(new KeyValuePair<int, Move>(MinMax(Rules.MakeMove(move), depth - 1, !maximazing), move));
            }

            if (maximazing)
                return points.Max(point => point.Key);
            else
                return points.Min(point => point.Key);
        }

        private int EvaluateBoard(GameState state)
        {
            var winner = this.Rules.CheckForWinner();
            if (winner.HasValue)
            {
                if (winner.Value.Equals(Position))
                    return 1;
                else
                    return -1;
            }
            else
                return 0;
        }
    }
}

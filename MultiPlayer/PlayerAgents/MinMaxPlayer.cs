using MultiPlayer.Games;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiPlayer.PlayerAgents
{
    public class MinMaxPlayer<TGame> : Player 
        where TGame : Game, new()
    {
        protected TGame Game;

        public MinMaxPlayer(int position) : base(position)
        {
            Game = new TGame();
        }

        public override string Name { get; set; } = "Min Max Player";

        public override Move ChooseMove(GameState gameState, List<Move> legalMoves)
        {
            var gameStateCopy = gameState;
            List<KeyValuePair<int, Move>> points = new List<KeyValuePair<int, Move>>();
            foreach (Move move in legalMoves)
            {
                points.Add(new KeyValuePair<int, Move>(MinMax(Game.Rules.MakeMove(gameStateCopy, move), depth: 100, maximazing: true), move));
            }
            var max = from x in points where x.Key == points.Max(v => v.Key) select x.Value;
            return max.First();
        }

        private int MinMax(GameState gameState, int depth, bool maximazing)
        {
            Game.GameState = gameState;

            if (depth == 0 || Game.Rules.LegalMoves(Game.GameState).Count == 0)
            {
                return EvaluateBoard(gameState) + depth;
            }

            List<KeyValuePair<int, Move>> points = new List<KeyValuePair<int, Move>>();
            foreach (var move in Game.Rules.LegalMoves(Game.GameState))
            {
                var gameStateCopy = gameState;
                points.Add(new KeyValuePair<int, Move>(MinMax(Game.Rules.MakeMove(gameStateCopy, move), depth - 1, !maximazing), move));
            }

            if (maximazing)
                return points.Max(point => point.Key);
            else
                return points.Min(point => point.Key);
        }

        private int EvaluateBoard(GameState state)
        {
            var winner = Game.Rules.CheckForWinner(state);
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

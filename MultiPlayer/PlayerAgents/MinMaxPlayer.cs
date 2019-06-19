using MultiPlayer.Games;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiPlayer.PlayerAgents
{
    public class MinMaxPlayer<TGame> : Player 
        where TGame : Game, new()
    {
        public MinMaxPlayer(int position) : base(position)
        {
        }

        public override string Name { get; set; } = "Min Max Player";

        public override Move ChooseMove(in GameState gameState, List<Move> legalMoves)
        {
            List<KeyValuePair<int, Move>> points = new List<KeyValuePair<int, Move>>();
            foreach (Move move in legalMoves)
            {
                var gameStateCopyBase = gameState.Clone() as GameState;
                var game = new TGame
                {
                    GameState = gameStateCopyBase
                };
                game.Rules.MakeMove(gameStateCopyBase, move);
                points.Add(new KeyValuePair<int, Move>(MinMax(gameStateCopyBase, depth: -1, maximazing: false), move));
            }
            var max = from x in points where x.Key == points.Max(v => v.Key) select x.Value;
            return max.First();
        }

        /// <returns>Points</returns>
        private int MinMax(GameState gameState, int depth, bool maximazing)
        {
            var game = new TGame
            {
                GameState = gameState
            };
            if (depth == 0 || game.Rules.LegalMoves(gameState).Count == 0)
            {
                return EvaluateBoard(gameState) * 100;
            }

            List<KeyValuePair<int, Move>> points = new List<KeyValuePair<int, Move>>();
            var legalMoves = game.Rules.LegalMoves(gameState);
            foreach (var move in legalMoves)
            {
                var gameStateCopy = gameState.Clone() as GameState;
                game = new TGame
                {
                    GameState = gameStateCopy
                };
                game.Rules.MakeMove(gameStateCopy, move);
                points.Add(new KeyValuePair<int, Move>(MinMax(gameStateCopy, depth - 1, !maximazing), move));
            }

            if (maximazing)
                return points.Max(point => point.Key) - 1;
            else
                return points.Min(point => point.Key) + 1;
        }

        private int EvaluateBoard(GameState state)
        {
            var game = new TGame
            {
                GameState = state
            };
            if (game.Rules.Winner.HasValue)
            {
                if (game.Rules.Winner.Value.Equals(Position))
                    return 1;
                else
                    return -1;
            }
            else
                return 0;
        }
    }
}

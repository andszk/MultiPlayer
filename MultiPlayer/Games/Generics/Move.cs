using MultiPlayer.Games;

namespace MultiPlayer
{
    public abstract class Move
    {
        public abstract GameState Execute(GameState gameState);
    }
}
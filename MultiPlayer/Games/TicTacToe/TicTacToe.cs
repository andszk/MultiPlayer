using System;


namespace MultiPlayer.Games.TicTacToe
{
    public class TicTacToe : Game
    {
        public override Rules Rules { get; } = new TicTacToeRules();
        public override GameState GameState { get; set; }

        public TicTacToe()
        {
            GameState = new TTTGameState();
            GameState.ChooseFirstPlayer();
            (GameState as TTTGameState).GameStateChanged += HandleGameStateChangedEvent;
        }

        void HandleGameStateChangedEvent(object sender, EventArgs e)
        {
            Rules.CheckForWinner(GameState);
            GameState.NextPlayer();
        }
    }
}
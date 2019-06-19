using System;


namespace MultiPlayer.Games.TicTacToe
{
    public class TicTacToe : Game
    {
        public override Rules Rules { get; } = new TicTacToeRules();

        private GameState _gameState = new TTTGameState();
        public override GameState GameState
        {
            get => _gameState;
            set
            {
                _gameState = value;
                Rules.CheckForWinner(_gameState);
            }
        } 

        public TicTacToe()
        {
            GameState.ChooseFirstPlayer();
            (GameState as TTTGameState).GameStateChanged += Rules.HandleGameStateChanged;
        }
    }
}
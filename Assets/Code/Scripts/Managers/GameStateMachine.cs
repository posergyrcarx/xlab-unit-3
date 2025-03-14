public sealed class GameStateMachine
{
    IGameState gameState;

    public void ChangeState(IGameState newState)
    {
        if (gameState != null)
        {
            gameState.Exit();

            gameState = newState;
            gameState.Enter();
        }
    }

    public void Update()
    {
        gameState?.Execute();
    }
}

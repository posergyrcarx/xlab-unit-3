using GameStates;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameStateMachine gameStateMachine = new GameStateMachine();

    void Start()
    {
        gameStateMachine.ChangeState(new MainMenuState());
    }

    private void Update()
    {
        gameStateMachine.Update();
    }
}

using UnityEngine;

public interface IGameState
{
    public void Enter();
    public void Execute();
    public void Exit();
}

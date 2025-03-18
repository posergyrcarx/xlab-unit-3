using UnityEngine;
using static GameManager;

public class Startup : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public void Awake()
    {
        gameManager.SetState(gameManager.state = GameState.MainMenu);
    }
}
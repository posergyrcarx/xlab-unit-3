using Code.Scripts.Managers;
using UnityEngine;
using static Code.Scripts.Managers.GameManager;

namespace Code.Scripts
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        public void Awake()
        {
            gameManager.SetState(gameManager.state = GameState.MainMenu);
        }
    }
}
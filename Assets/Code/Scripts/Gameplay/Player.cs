using Code.ScriptableObjects;
using UnityEngine;

namespace Code.Scripts.Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private SpecsPlayer specsPlayer;
        private float _punchStrength;

        private void Start()
        {
            _punchStrength = specsPlayer.Strength;
        }
    }
}

using Code.ScriptableObjects;
using UnityEngine;

namespace Code.Scripts.Gameplay
{
    public class Stone : MonoBehaviour
    {
        [SerializeField] private SpecsObject specsStone;
        public static System.Action OnCollisionStone;
    }
}

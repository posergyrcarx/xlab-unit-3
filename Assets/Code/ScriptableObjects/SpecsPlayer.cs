using UnityEngine;

namespace Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Specification", menuName = "Specification/Player Specification", order = 1)]
    public class SpecsPlayer : ASpecs
    {
        [SerializeField] private float punchStrength;
        public float Strength => punchStrength;
    }
}
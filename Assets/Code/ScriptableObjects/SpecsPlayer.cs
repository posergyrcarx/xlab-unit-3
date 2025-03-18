using UnityEngine;

namespace Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Specification", menuName = "Specifications/Player Specs", order = 1)]
    public class SpecsPlayer : ASpecs
    {
        [SerializeField] private float punchStrength;
        public float Strength => punchStrength;
    }
}
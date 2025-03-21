using UnityEngine;

[CreateAssetMenu(fileName = "Player Specification", menuName = "Specification/Player Specification", order = 1)]
public class SpecsPlayer : ASpecs
{
    [SerializeField] float punchStrength;
    public float Strength => punchStrength;
}
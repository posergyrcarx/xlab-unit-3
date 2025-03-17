using UnityEngine;

[CreateAssetMenu(fileName = "Player Specification", menuName = "Specifications/Player Specs", order = 1)]
public class SpecsPlayer : ASpecs
{
    [SerializeField] float punchStrength;
    public float Strength => punchStrength;
}
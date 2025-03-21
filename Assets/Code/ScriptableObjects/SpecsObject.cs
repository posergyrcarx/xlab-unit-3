using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Object Specification",  menuName = "Specification/Object Specification", order = 2)]
public class SpecsObject : ASpecs
{
    [SerializeField] MassType massType;
    [Space]
    [SerializeField] float mass;
    [SerializeField] Vector2 randomMass;

    [Serializable]
    public enum MassType
    {
        Float,
        Random
    }
}
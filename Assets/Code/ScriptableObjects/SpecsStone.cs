using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Stone Specification",  menuName = "Specifications/Stone Specs", order = 2)]
public class SpecsStone : ASpecs
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
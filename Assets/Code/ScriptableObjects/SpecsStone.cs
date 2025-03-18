using System;
using UnityEngine;

namespace Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Stone Specification",  menuName = "Specifications/Stone Specs", order = 2)]
    public class SpecsStone : ASpecs
    {
        [SerializeField] private MassType massType;
        [Space]
        [SerializeField]
        private float mass;
        [SerializeField] private Vector2 randomMass;

        [Serializable]
        public enum MassType
        {
            Float,
            Random
        }
    }
}
using System;
using UnityEngine;

namespace Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Object Specification",  menuName = "Specification/Object Specification", order = 2)]
    public class SpecsObject : ASpecs
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
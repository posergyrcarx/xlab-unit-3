using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Packages.SerializedCollections.Sample
{
    public class SerializedDictionarySampleThree : MonoBehaviour
    {
        [SerializeField]
        private SerializedDictionary<ScriptableObject, string> _nameOverrides;
    }
}
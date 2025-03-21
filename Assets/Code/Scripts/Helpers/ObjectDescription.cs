using UnityEngine;

namespace Code.Scripts.Helpers
{
    public class ObjectDescription : MonoBehaviour
    {
        [TextArea(3, 5)][SerializeField] private string note;
    }
}
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] SpecsPlayer specsPlayer;
    private float punchStrength;

    private void Start()
    {
        punchStrength = specsPlayer.Strength;
    }
}

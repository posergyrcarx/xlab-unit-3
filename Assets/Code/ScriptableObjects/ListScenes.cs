using UnityEngine;

[CreateAssetMenu(fileName = "Scenes List", menuName = "List/Scenes List")]
public class ListScenes : AList
{
    [SerializeField] private string[] scenesToLoad;
    public string[] ScenesToLoad => scenesToLoad;
}

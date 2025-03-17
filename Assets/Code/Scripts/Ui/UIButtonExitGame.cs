using UnityEngine;

public class UIButtonExitGame : MonoBehaviour
{
    public void DoExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

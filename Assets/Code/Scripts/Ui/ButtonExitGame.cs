using UnityEngine;

public class ButtonExitGame : MonoBehaviour
{
    public void doExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

using System;
using UnityEditor;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    public static event Action OnUpdateUiEvent;
    public static event Action OnReloadGameEvent;

    [MenuItem("Debug/Reload Game")]
    private static void ReloadGame()
    {
        OnReloadGameEvent.Invoke();
    }

    [MenuItem("Debug/Reload Screen (UI)")]
    private static void ReloadScreen()
    {
        OnUpdateUiEvent.Invoke();
    }
}



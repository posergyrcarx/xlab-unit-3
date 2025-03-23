namespace Code.Scripts.Helpers
{
    public static class DebugMessage
    {
            public static void LogSuccess(this object senderName, params object[] message)
        {
#if UNITY_EDITOR

            UnityEngine.Debug.Log($"<color=#7DAF33>■</color> <color=#999999>{senderName}</color> <color=#D2D2D2>:</color> " +
                                  $"<color=#E0DEDF>{string.Join(" ", message)}</color>");
#endif
        }
        
        /// <summary>
        /// Use this. , GetType().Name as a default parameter for senderComponent
        /// </summary>
        public static void LogInfo(this object senderName, params object[] message)
        {
#if UNITY_EDITOR
                UnityEngine.Debug.Log($"<color=#3CABCD>●</color> <color=#999999>{senderName}</color> <color=#D2D2D2>:</color> " +
                                      $"<color=#E0DEDF>{string.Join("", message)}</color>");
#endif
        }
        
        /// <summary>
        /// Use this. , GetType().Name as a default parameter for senderComponent
        /// </summary>
        public static void LogWarning(this object senderName, params object[] message)
        {
#if UNITY_EDITOR

            UnityEngine.Debug.LogWarning($"<color=#FFC008>▲</color> <color=#999999>{senderName}</color> <color=#D2D2D2>:</color> " +
                                         $"<color=#E0DEDF>{string.Join(" ", message)}</color>");
#endif
        }
        
        /// <summary>
        /// Use this. , GetType().Name as a default parameter for senderComponent
        /// </summary>
        public static void LogError(this object senderName, params object[] message)
        {
#if UNITY_EDITOR

            UnityEngine.Debug.LogError($"<color=#FF6E41>▼</color> <color=#999999>{senderName}</color> <color=#D2D2D2>:</color> " +
                                       $"<color=#E0DEDF>{string.Join(" ", message)}</color>");
#endif
        }
    }
}
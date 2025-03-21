using UnityEngine;

namespace Code.Scripts.Helpers
{
    /// <summary>
    /// A static instance is similar to a singleton, but instead of destroying an new
    /// instances, it overrides the current instance. This is handy for resetting
    /// the state and saves you doing it manually
    /// </summary>
    public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T Instance { get; private set; }
        protected virtual void Awake() => Instance = this as T;

        protected void OnApplicationQuit()
        {
            Instance = null;
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// This transforms the static instance into a basic singleton. This will destroy
    /// any new versions created, leaving the original instance intact
    /// </summary>
    public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            
            base.Awake();
        }
    }

    /// <summary>
    /// This will survive through scene loads. Perfect for system classes which
    /// require stateful, persistent data, or audio sources where music plays
    /// through loading etc.
    /// </summary>
    public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}

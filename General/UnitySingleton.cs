using UnityEngine;

namespace UnityTools.General
{
    /// <summary>
    /// Inherit from this class to create a simple singleton
    /// </summary>
    /// <typeparam name="T">the singleton class</typeparam>
    public class UnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static T Instance { get; private set; }

        protected  virtual void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            else Instance = this as T;
        }
    }
}
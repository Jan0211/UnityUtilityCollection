using System.Collections.Generic;
using UnityEngine;

namespace UnityTools.InitializationHandling
{
    public abstract class Initializable : MonoBehaviour
    {
        // public static readonly List<Initializable> DebugNotInitializedObjects = new List<Initializable>();
        //
        // public Observable<bool> IsInitialized;
        //
        // protected void Awake()
        // {
        //     Debug.Log("Awake Initializable");
        //
        //     AwakeInitialization();
        //
        //     if (IsInitialized == null)
        //         Debug.Log("You forgor to init");
        //     else
        //         Debug.Log("You did not forgor. Good child :)");
        // }
        //
        // protected void Start()
        // {
        //     StartInitialization();
        //     if (IsInitialized.Value != true)
        //     {
        //         DebugNotInitializedObjects.Add(this);
        //         IsInitialized.ValueChanged += (sender, value, newValue) => DebugNotInitializedObjects.Remove(this);
        //     }
        // }
        //
        // /*
        //  * nach StartInitialization überprüfen, ob IsInitialized != null ist
        //  * => wenn nicht, error. Wurde vergessen.
        //  */
        //
        // protected abstract void AwakeInitialization();
        //
        // protected virtual void StartInitialization()
        // {
        //
        // }
    }
}

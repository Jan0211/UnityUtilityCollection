using UnityEditor;
using UnityEngine;

namespace UnityTools.EditorScripts
{
    public static class DebugGlobalPosition
    {
        [MenuItem("Debug/GlobalPosition")]
        public static void DisplayGlobalPosition()
        {
            if (Selection.activeGameObject == null) return;
            var pos = Selection.activeGameObject.transform.position;
            Debug.Log($"GlobalPosition: {pos}");
        }
    }
}
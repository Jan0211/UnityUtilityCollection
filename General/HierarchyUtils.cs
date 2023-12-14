using UnityEngine;

namespace UUC.General
{
    public static class HierarchyUtils
    {
        /// <summary>
        /// Recursively switches the layer of <see cref="parent"/> gameobject and all its children.
        ///
        /// <para>Created by @LeHoppel.</para>
        /// </summary>
        /// <param name="parent">The parent gameobject.</param>
        /// <param name="targetLayer">The layer to switch all gameobjects to.</param>
        public static void RecursiveLayerSwitch(GameObject parent, int targetLayer)
        {
            parent.layer = targetLayer;

            foreach (Transform child in parent.transform)
                RecursiveLayerSwitch(child.gameObject, 0);
        }
    }
}

# UnityUtilityCollection
A collection of tools and scripts useful for game development with Unity.

EditorScripts:
- DebugGlobalPosition: Adds an editor debugging option for the global position of any gameobject.
- ReadOnlyDrawer: Attribute which makes a serialized field read only in the editor inspector.

General:
- UnitySingleton: Inherit from this class to create a simple singleton.
- HierarchyUtils: Useful functions concerning the scene hierarchy (e.g. get full scene path or recursive layer switching).
- MathUtils: Extends Unity's MathF library with missing features.

InitializationHandling:
- WIP implemenation of Initializable interface.

ScriptTemplates:
- Collection of useful templates (e.g. when creating a new script).

TransformUtilities:
- Collection of components which change the position, rotation or scale of a gameobject.
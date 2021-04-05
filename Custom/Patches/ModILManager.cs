namespace TerraTemp.Custom.Patches {

    /// <summary>
    /// Manages all IL Edits that affect methods from other mods rather than from vanilla or tML.
    /// </summary>
    public static class ModILManager {

        public delegate void VoidDelegate();

        public static event VoidDelegate LoadEvent;

        public static event VoidDelegate UnloadEvent;

        public static void LoadILEdits() {
            LoadEvent?.Invoke();
        }

        public static void UnloadILEdits() {
            UnloadEvent?.Invoke();
        }
    }
}
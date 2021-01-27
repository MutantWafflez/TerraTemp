using System;
using TerraTemp.Content.ModChanges;

namespace TerraTemp.Custom.Attributes {

    /// <summary>
    /// Attribute that is used for modded change classes such as <see cref="ModEvent"/> to determine
    /// what Mod Type that child class pertains to.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PertainedMod : Attribute {
        public readonly Type pertainedMod;

        public PertainedMod(Type modType) {
            pertainedMod = modType;
        }
    }
}
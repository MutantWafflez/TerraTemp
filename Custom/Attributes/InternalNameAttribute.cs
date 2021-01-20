using System;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Custom.Attributes {

    /// <summary>
    /// Attribute that is used to initially set and then get the internal mod name of a given <see cref="ReflectionMod"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class InternalModName : Attribute {
        public readonly string name;

        public InternalModName(string internalName) {
            name = internalName;
        }
    }
}
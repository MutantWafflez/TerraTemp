using System;
using System.Reflection;
using Terraria.ModLoader;
using TerraTemp.Custom.Attributes;

namespace TerraTemp.Custom.Classes.ReflectionMod {

    /// <summary>
    /// Class that handles other mods for creating mod compatability with reflection. The
    /// InernalModName Attribute attached is REQUIRED for proper fuctionality: it's parameter is
    /// simply the internal name of the mod in question.
    /// </summary>
    [InternalModName(null)]
    public abstract class ReflectionMod {
        public readonly Mod ModInstance;

        public readonly Assembly ModAssembly;

        public readonly Type[] ModTypes;

        public ReflectionMod(Mod instance) {
            ModInstance = instance;
            ModAssembly = ModInstance.GetType().Assembly;
            ModTypes = ModAssembly.GetTypes();
        }
    }
}
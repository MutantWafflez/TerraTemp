global using Terraria;
global using Terraria.ID;
global using Terraria.ModLoader;
using log4net;

namespace TerraTemp {
    /// <summary>
    /// The Mod. Has only very basic properties and fields for the very core of the mod, as well as
    /// handles the Packets. If you're looking for the actual content that used to be in this class,
    /// check the Systems Folder within the Common Folder.
    /// </summary>
    public class TerraTemp : Mod {
        /// <summary>
        /// The string of the directory for all of the miscellaneous textures for TerraTemp.
        /// </summary>
        public const string TextureDirectory = nameof(TerraTemp) + "/Assets/Sprites/";

        /// <summary>
        /// Logger class for TerraTemp.
        /// </summary>
        internal static ILog Logging = LogManager.GetLogger("TerraTemp");
    }
}
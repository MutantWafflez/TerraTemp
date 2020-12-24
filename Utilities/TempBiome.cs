using Terraria;

namespace TerraTemp.Utilities {
    /// <summary>
    /// Class that is instantiated for each biome in the game that affects temperature
    /// </summary>
    public abstract class TempBiome {
        /// <summary>
        /// How much this biome will change the enivronment temperature.
        /// </summary>
        public virtual float TemperatureModification => 0f;

        /// <summary>
        /// How much this biome will change the player's temperature resistance.
        /// </summary>
        public virtual float TemperatureResistanceModification => 0f;

        /// <summary>
        /// Zone bool that relates to this biome.
        /// </summary>
        public virtual bool PlayerZoneBool(Player player) => false;

    }

    /// <summary>
    /// Class that is instantiated for each evil biome (including the Hallow) that affects temperature.
    /// Exists so the evil biomes can affect temperature on top of the normal biome effects.
    /// </summary>
    public abstract class EvilTempBiome {
        /// <summary>
        /// How much this evil biome will change the enivronment temperature.
        /// </summary>
        public virtual float TemperatureModification => 0f;

        /// <summary>
        /// How much this evil biome will change the player's temperature resistance.
        /// </summary>
        public virtual float TemperatureResistanceModification => 0f;

        /// <summary>
        /// Zone bool that relates to this evil biome.
        /// </summary>
        public virtual bool EvilZoneBool(Player player) => false;
    }
}

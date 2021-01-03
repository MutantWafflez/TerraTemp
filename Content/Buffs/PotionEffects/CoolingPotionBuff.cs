using Terraria;
using Terraria.ModLoader;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Buffs.PotionEffects {

    public class CoolingPotionBuff : ModBuff {
        private readonly float heatComfortabilityIncrease = 8f;

        public override void SetDefaults() {
            DisplayName.SetDefault("Cooled");
            Description.SetDefault(TempUtilities.GetTerraTempTextValue("GlobalTooltip.IncreasedHeatComfortability", heatComfortabilityIncrease));
        }

        public override void Update(Player player, ref int buffIndex) {
            player.GetTempPlayer().comfortableHigh += heatComfortabilityIncrease;
        }
    }
}
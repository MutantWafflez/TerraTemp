using Terraria;

namespace TerraTemp.Content.Buffs.PotionEffects {

    public class CoolingPotionBuff : TemperatureBuff {

        public override float GetHeatComfortabilityChange(Player player) => 8f;

        public override void SetStaticDefaults() {
            CanBeCleared = true;
        }
    }
}
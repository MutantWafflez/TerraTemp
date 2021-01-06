namespace TerraTemp.Content.Buffs.PotionEffects {

    public class CoolingPotionBuff : TemperatureBuff {
        public override float HeatComfortabilityChange => 8f;

        public override void SetDefaults() {
            canBeCleared = true;
        }
    }
}
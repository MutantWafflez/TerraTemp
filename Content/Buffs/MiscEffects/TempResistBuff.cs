namespace TerraTemp.Content.Buffs.MiscEffects {

    public class TempResistBuff : TemperatureBuff {
        public override float TemperatureResistanceChange => 0.4f;

        public override void SetDefaults() {
            canBeCleared = true;
        }
    }
}
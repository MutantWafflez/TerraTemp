using Terraria;

namespace TerraTemp.Content.Buffs.MiscEffects {
    public class TempResistBuff : TemperatureBuff {
        public override float GetTemperatureResistanceChange(Player player) => 0.4f;
    }
}
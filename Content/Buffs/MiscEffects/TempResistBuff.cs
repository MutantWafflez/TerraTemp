using Terraria;
using Terraria.ModLoader;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Buffs.MiscEffects {

    public class TempResistBuff : ModBuff {

        public override void SetDefaults() {
            DisplayName.SetDefault("Temperature Resistance");
            Description.SetDefault(TempUtilities.GetTerraTempTextValue("GlobalTooltip.IncreasedTempResistance", 0.4f));
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.GetTempPlayer().temperatureChangeResist += 0.4f;
        }
    }
}
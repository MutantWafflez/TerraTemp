using Terraria;
using Terraria.ModLoader;
using TerraTemp.Content.Buffs.TempEffects;

namespace TerraTemp.Common.Systems {

    public class ScreenHandlerSystem : ModSystem {

        public override void ModifyLightingBrightness(ref float scale) {
            //Hypothermia/Heat Stroke "Blackout" Effect
            if (Main.LocalPlayer.HasBuff(ModContent.BuffType<Hypothermia>()) || Main.LocalPlayer.HasBuff(ModContent.BuffType<HeatStroke>())) {
                scale -= 0.34f;
            }
        }
    }
}
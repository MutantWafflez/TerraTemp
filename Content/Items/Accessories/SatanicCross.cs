using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Base.Items;

namespace TerraTemp.Content.Items.Accessories {

    [AutoloadEquip(EquipType.Neck)]
    public class SatanicCross : TempEquipment {

        public override void SetDefaults() {
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Orange;
        }

        public override float GetSunExtremityChange(Player player) => 0.666f;

        public override void UpdateAccessory(Player player, bool hideVisual) {
            if (Main.dayTime && player.ZoneOverworldHeight) {
                if (Main.time <= 27000 /* Noon */) {
                    player.GetDamage(DamageClass.Generic) += (float)Math.Round(((float)Main.time / 27000f) * 0.20f);
                }
                else {
                    player.GetDamage(DamageClass.Generic) += (float)Math.Round(((54000f - (float)Main.time) / 27000f) * 0.20f);
                }
            }
        }

        //Overriden so that we can apply our custom tooltip
        public override void ModifyTooltips(List<TooltipLine> tooltips) { }
    }
}
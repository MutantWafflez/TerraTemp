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
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Orange;
        }

        public override float GetSunExtremityChange(Player player) => 0.666f;

        public override void UpdateAccessory(Player player, bool hideVisual) {
            if (Main.dayTime && player.ZoneOverworldHeight) {
                if (Main.time <= 27000 /* Noon */) {
                    player.allDamageMult += (float)Math.Round(((float)Main.time / 27000f) * 0.20f);
                }
                else {
                    player.allDamageMult += (float)Math.Round(((54000f - (float)Main.time) / 27000f) * 0.20f);
                }
            }
        }

        //Overriden so that we can apply our custom tooltip
        public override void ModifyTooltips(List<TooltipLine> tooltips) { }
    }
}
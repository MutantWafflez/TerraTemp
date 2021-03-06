﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Base.Items;

namespace TerraTemp.Content.Items.Accessories {

    public class RiskBadge : TempEquipment {

        public override float GetTemperatureResistanceChange(Player player) => -10f;

        public override float GetClimateExtremityChange(Player player) => 0.3f;

        public override void SetDefaults() {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.endurance += 0.25f;
        }

        //Overriding this so the automatic tooltip system doesn't say "-1000% temperature change resistance"
        //Check .lang file for actual translation
        public override void ModifyTooltips(List<TooltipLine> tooltips) { }
    }
}
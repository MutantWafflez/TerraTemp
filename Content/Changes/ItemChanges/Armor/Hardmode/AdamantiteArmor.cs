﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class AdamantiteHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AdamantiteHelmet,
            ItemID.AdamantiteMask,
            ItemID.AdamantiteHeadgear
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class AdamantiteChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AdamantiteBreastplate
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class AdamantiteLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AdamantiteLeggings
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class AdamantiteArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.AdamantiteHelmet,
            ItemID.AdamantiteMask,
            ItemID.AdamantiteHeadgear
        };

        public override int ChestPieceID => ItemID.AdamantiteBreastplate;

        public override int LegPieceID => ItemID.AdamantiteLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetTempPlayer().temperatureChangeResist += MathHelper.Clamp(Math.Abs(player.velocity.Length() / 10f), 0f, 0.67f);
        }
    }
}
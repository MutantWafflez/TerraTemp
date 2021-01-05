﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class TikiHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TikiMask
        };

        public override float HeatComfortabilityChange => 1f;

        public override float ColdComfortabilityChange => 1f;
    }

    public class TikiChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TikiShirt
        };

        public override float HeatComfortabilityChange => 2f;

        public override float ColdComfortabilityChange => 2f;
    }

    public class TikiLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TikiPants
        };

        public override float HeatComfortabilityChange => 1f;

        public override float ColdComfortabilityChange => 1f;
    }

    public class TikiArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.TikiMask
        };

        public override int ChestPieceID => ItemID.TikiShirt;

        public override int LegPieceID => ItemID.TikiPants;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetTempPlayer().temperatureChangeResist += 0.075f * player.numMinions;
        }
    }
}
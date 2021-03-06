﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class MoltenHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MoltenHelmet
        };

        public override float GetDesiredTemperatureChange(Player player) => 2f;
    }

    public class MoltenChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MoltenBreastplate
        };

        public override float GetDesiredTemperatureChange(Player player) => 4f;
    }

    public class MoltenLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MoltenGreaves
        };

        public override float GetDesiredTemperatureChange(Player player) => 2f;
    }

    public class MoltenArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.MoltenHelmet
        };

        public override int ChestPieceID => ItemID.MoltenBreastplate;

        public override int LegPieceID => ItemID.MoltenGreaves;

        public override float GetColdComfortabilityChange(Player player) => -8f;
    }
}
using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class ObsidianHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.ObsidianHelm
        };

        public override float HeatComfortabilityChange => 3f;
    }

    public class ObsidianChestpiece : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.ObsidianShirt
        };

        public override float HeatComfortabilityChange => 4f;
    }

    public class ObsidianLegs : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.ObsidianPants
        };

        public override float HeatComfortabilityChange => 3f;
    }

    public class ObsidianArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int> {
            ItemID.ObsidianHelm
        };

        public override int ChestPieceID => ItemID.ObsidianShirt;

        public override int LegPieceID => ItemID.ObsidianPants;

        public override string AdditionalSetBonusText => "Grants the effect of the Obsidian Rose";

        public override void AdditionalSetBonusEffect(Player player) {
            player.lavaRose = true;
        }
    }
}
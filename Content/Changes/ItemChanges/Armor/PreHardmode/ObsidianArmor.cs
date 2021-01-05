using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class ObsidianHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.ObsidianHelm
        };

        public override float HeatComfortabilityChange => 3f;
    }

    public class ObsidianChestpiece : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.ObsidianShirt
        };

        public override float HeatComfortabilityChange => 4f;
    }

    public class ObsidianLegs : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.ObsidianPants
        };

        public override float HeatComfortabilityChange => 3f;
    }

    public class ObsidianArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int> {
            ItemID.ObsidianHelm
        };

        public override int ChestPieceID => ItemID.ObsidianShirt;

        public override int LegPieceID => ItemID.ObsidianPants;

        public override void AdditionalSetBonusEffect(Player player) {
            player.lavaRose = true;
        }
    }
}
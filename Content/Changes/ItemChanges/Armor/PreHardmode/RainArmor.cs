using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class RainHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.RainHat
        };

        public override float ColdComfortabilityChange => -1f;
    }

    public class RainChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.RainCoat
        };

        public override float ColdComfortabilityChange => -2f;
    }

    public class RainArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.RainHat
        };

        public override int ChestPieceID => ItemID.RainCoat;

        public override void AdditionalSetBonusEffect(Player player) {
            if (Main.raining) {
                player.GetModPlayer<TempPlayer>().criticalRangeMaximum += 5f;
            }
        }
    }
}
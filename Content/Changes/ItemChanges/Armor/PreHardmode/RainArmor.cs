using System.Collections.Generic;
using Terraria;
using Terraria.ID;

using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class RainHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.RainHat
        };

        public override float GetColdComfortabilityChange(Player player) => -1f;
    }

    public class RainChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.RainCoat
        };

        public override float GetColdComfortabilityChange(Player player) => -2f;
    }

    public class RainArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.RainHat
        };

        public override int ChestPieceID => ItemID.RainCoat;

        public override void AdditionalSetBonusEffect(Player player) {
            if (Main.raining) {
                player.GetTempPlayer().criticalRangeMaximum += 5f;
            }
        }
    }
}
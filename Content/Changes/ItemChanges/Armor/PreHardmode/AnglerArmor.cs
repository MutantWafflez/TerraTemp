using System.Collections.Generic;
using Terraria;
using Terraria.ID;

using TerraTemp.Custom;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class AnglerHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AnglerHat
        };

        public override float GetHeatComfortabilityChange(Player player) => 1f;
    }

    public class AnglerChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AnglerVest
        };

        public override float GetHeatComfortabilityChange(Player player) => 2f;
    }

    public class AnglerLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AnglerPants
        };

        public override float GetHeatComfortabilityChange(Player player) => 1f;
    }

    public class AnglerArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.AnglerHat
        };

        public override int ChestPieceID => ItemID.AnglerVest;

        public override int LegPieceID => ItemID.AnglerPants;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetTempPlayer().temperatureChangeResist += (player.fishingSkill / 100f) * 0.34f;
        }
    }
}
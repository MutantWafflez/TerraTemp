using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ShroomiteHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ShroomiteHelmet,
            ItemID.ShroomiteHeadgear,
            ItemID.ShroomiteMask
        };

        public override float TemperatureResistanceChange => 0.025f;
    }

    public class ShroomiteChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ShroomiteBreastplate
        };

        public override float TemperatureResistanceChange => 0.05f;
    }

    public class ShroomiteLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ShroomiteLeggings
        };

        public override float TemperatureResistanceChange => 0.025f;
    }

    public class ShroomiteArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.ShroomiteHelmet,
            ItemID.ShroomiteHeadgear,
            ItemID.ShroomiteMask
        };

        public override int ChestPieceID => ItemID.ShroomiteBreastplate;

        public override int LegPieceID => ItemID.ShroomiteLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetTempPlayer().temperatureChangeResist += 0.7f * (1f - player.stealth);
        }
    }
}
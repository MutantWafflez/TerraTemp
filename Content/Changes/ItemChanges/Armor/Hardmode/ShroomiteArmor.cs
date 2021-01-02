using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ShroomiteHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ShroomiteHelmet,
            ItemID.ShroomiteHeadgear,
            ItemID.ShroomiteMask
        };

        public override float TemperatureResistanceChange => 0.025f;
    }

    public class ShroomiteChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ShroomiteBreastplate
        };

        public override float TemperatureResistanceChange => 0.05f;
    }

    public class ShroomiteLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ShroomiteLeggings
        };

        public override float TemperatureResistanceChange => 0.025f;
    }

    public class ShroomiteArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.ShroomiteHelmet,
            ItemID.ShroomiteHeadgear,
            ItemID.ShroomiteMask
        };

        public override int ChestPieceID => ItemID.ShroomiteBreastplate;

        public override int LegPieceID => ItemID.ShroomiteLeggings;

        public override string ArmorSetName => "ShroomiteArmor";

        public override string AdditionalSetBonusText => "80% increased temperature change resistance while in stealth";

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetModPlayer<TempPlayer>().temperatureChangeResist += 0.8f * (1f - player.stealth);
        }
    }
}
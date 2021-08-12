using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class CrystalAssassinHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CrystalNinjaHelmet
        };

        public override float GetColdComfortabilityChange(Player player) => -2f;
    }

    public class CrystalAssassinChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CrystalNinjaChestplate
        };

        public override float GetColdComfortabilityChange(Player player) => -3f;
    }

    public class CrystalAssassinLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CrystalNinjaLeggings
        };

        public override float GetColdComfortabilityChange(Player player) => -2f;
    }

    public class CrystalAssassinArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.CrystalNinjaHelmet
        };

        public override int ChestPieceID => ItemID.CrystalNinjaChestplate;

        public override int LegPieceID => ItemID.CrystalNinjaLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (!Main.dayTime) {
                player.GetTempPlayer().temperatureChangeResist += 0.34f;
            }
        }
    }
}
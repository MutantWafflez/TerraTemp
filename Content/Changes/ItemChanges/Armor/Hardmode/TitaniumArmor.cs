using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class TitaniumHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TitaniumHelmet,
            ItemID.TitaniumMask,
            ItemID.TitaniumHeadgear
        };

        public override float DesiredTemperatureChange => -2f;
    }

    public class TitaniumChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TitaniumBreastplate
        };

        public override float DesiredTemperatureChange => -3f;
    }

    public class TitaniumLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TitaniumLeggings
        };

        public override float DesiredTemperatureChange => -1f;
    }

    public class TitaniumArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.TitaniumHelmet,
            ItemID.TitaniumMask,
            ItemID.TitaniumHeadgear
        };

        public override int ChestPieceID => ItemID.TitaniumBreastplate;

        public override int LegPieceID => ItemID.TitaniumLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.HasBuff(BuffID.ShadowDodge)) {
                player.GetTempPlayer().comfortableLow -= 8f;
            }
        }
    }
}
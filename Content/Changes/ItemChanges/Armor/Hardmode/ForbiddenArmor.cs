using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Common.Players;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ForbiddenHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AncientBattleArmorHat
        };

        public override float ColdComfortabilityChange => 2f;

        public override float HeatComfortabilityChange => 4f;
    }

    public class ForbiddenChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AncientBattleArmorShirt
        };

        public override float ColdComfortabilityChange => 2f;

        public override float HeatComfortabilityChange => 4f;
    }

    public class ForbiddenLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AncientBattleArmorPants
        };

        public override float ColdComfortabilityChange => 2f;

        public override float HeatComfortabilityChange => 4f;
    }

    public class ForbiddenArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.AncientBattleArmorHat
        };

        public override int ChestPieceID => ItemID.AncientBattleArmorShirt;

        public override int LegPieceID => ItemID.AncientBattleArmorPants;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetModPlayer<AccessoryPlayer>().flameRune = true;
        }
    }
}
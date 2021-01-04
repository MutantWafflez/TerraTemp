using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ForbiddenHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.AncientBattleArmorHat
        };
    }

    public class ForbiddenChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.AncientBattleArmorShirt
        };
    }

    public class ForbiddenLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.AncientBattleArmorPants
        };
    }

    public class ForbiddenArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.AncientBattleArmorHat
        };

        public override int ChestPieceID => ItemID.AncientBattleArmorShirt;

        public override int LegPieceID => ItemID.AncientBattleArmorPants;
    }
}
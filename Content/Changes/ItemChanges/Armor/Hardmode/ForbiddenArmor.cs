using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ForbiddenHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AncientBattleArmorHat
        };
    }

    public class ForbiddenChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AncientBattleArmorShirt
        };
    }

    public class ForbiddenLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.AncientBattleArmorPants
        };
    }

    public class ForbiddenArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.AncientBattleArmorHat
        };

        public override int ChestPieceID => ItemID.AncientBattleArmorShirt;

        public override int LegPieceID => ItemID.AncientBattleArmorPants;
    }
}
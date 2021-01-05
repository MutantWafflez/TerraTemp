using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class DarkArtistHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeAltHead
        };
    }

    public class DarkArtistChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeAltShirt
        };
    }

    public class DarkArtistLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeAltPants
        };
    }

    public class DarkArtistArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.ApprenticeAltHead
        };

        public override int ChestPieceID => ItemID.ApprenticeAltShirt;

        public override int LegPieceID => ItemID.ApprenticeAltPants;
    }
}
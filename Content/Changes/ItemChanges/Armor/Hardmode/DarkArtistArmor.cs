using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class DarkArtistHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ApprenticeAltHead
        };
    }

    public class DarkArtistChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ApprenticeAltShirt
        };
    }

    public class DarkArtistLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ApprenticeAltPants
        };
    }

    public class DarkArtistArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.ApprenticeAltHead
        };

        public override int ChestPieceID => ItemID.ApprenticeAltShirt;

        public override int LegPieceID => ItemID.ApprenticeAltPants;
    }
}
using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class HallowedArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int> {
            ItemID.HallowedHelmet,
            ItemID.HallowedMask,
            ItemID.HallowedHeadgear
        };

        public override int ChestPieceID => ItemID.HallowedPlateMail;

        public override int LegPieceID => ItemID.HallowedGreaves;

        public override float TemperatureResistanceChange => 0.5f;
    }
}
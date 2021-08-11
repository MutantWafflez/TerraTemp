using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class HallowedArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int> {
            ItemID.HallowedHelmet,
            ItemID.HallowedMask,
            ItemID.HallowedHeadgear,
            ItemID.HallowedHood
        };

        public override int ChestPieceID => ItemID.HallowedPlateMail;

        public override int LegPieceID => ItemID.HallowedGreaves;

        public override float GetTemperatureResistanceChange(Player player) => 0.35f;
    }
}
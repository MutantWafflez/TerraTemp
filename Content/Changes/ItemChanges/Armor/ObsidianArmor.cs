using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor {

    public class ObsidianArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int> {
            ItemID.ObsidianHelm
        };

        public override int ChestPieceID => ItemID.ObsidianShirt;

        public override int LegPieceID => ItemID.ObsidianPants;

        public override string ArmorSetName => "ObsidianArmor";

        public override string AdditionalSetBonusText => "Grants the effect of the Obsidian Rose";
    }
}
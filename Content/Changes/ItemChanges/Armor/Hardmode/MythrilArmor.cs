using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Common.Players;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class MythrilHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MythrilHelmet,
            ItemID.MythrilHat,
            ItemID.MythrilHood
        };

        public override float CriticalTemperatureChange => -1f;
    }

    public class MythrilChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MythrilChainmail
        };

        public override float CriticalTemperatureChange => -1f;
    }

    public class MythrilLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MythrilGreaves
        };

        public override float CriticalTemperatureChange => -1f;
    }

    public class MythrilArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.MythrilHelmet,
            ItemID.MythrilHat,
            ItemID.MythrilHood
        };

        public override int ChestPieceID => ItemID.MythrilChainmail;

        public override int LegPieceID => ItemID.MythrilGreaves;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetModPlayer<SetBonusPlayer>().mythrilSetBonus = true;
        }
    }
}
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class TurtleHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TurtleHelmet
        };

        public override float HeatComfortabilityChange => 2f;

        public override float ColdComfortabilityChange => 1f;
    }

    public class TurtleChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TurtleScaleMail
        };

        public override float HeatComfortabilityChange => 2f;

        public override float ColdComfortabilityChange => 2f;
    }

    public class TurtleLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TurtleLeggings
        };

        public override float HeatComfortabilityChange => 3f;

        public override float ColdComfortabilityChange => 1f;
    }

    public class TurtleArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.TurtleHelmet
        };

        public override int ChestPieceID => ItemID.TurtleScaleMail;

        public override int LegPieceID => ItemID.TurtleLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.statLife < player.statLifeMax2) {
                player.GetTempPlayer().temperatureChangeResist += 0.7f * (1f - ((float)player.statLife / (float)player.statLifeMax2));
            }
        }
    }
}
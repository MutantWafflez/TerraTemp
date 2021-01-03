using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class TurtleHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TurtleHelmet
        };

        public override float HeatComfortabilityChange => 5f;

        public override float ColdComfortabilityChange => 2f;
    }

    public class TurtleChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TurtleScaleMail
        };

        public override float HeatComfortabilityChange => 6f;

        public override float ColdComfortabilityChange => 4f;
    }

    public class TurtleLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TurtleLeggings
        };

        public override float HeatComfortabilityChange => 5f;

        public override float ColdComfortabilityChange => 2f;
    }

    public class TurtleArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.TurtleHelmet
        };

        public override int ChestPieceID => ItemID.TurtleScaleMail;

        public override int LegPieceID => ItemID.TurtleLeggings;

        public override string AdditionalSetBonusText => "Gain up to 80% increased temperature change resistance as life lowers";

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.statLife < player.statLifeMax2) {
                player.GetModPlayer<TempPlayer>().temperatureChangeResist += 0.8f * (1f - ((float)player.statLife / (float)player.statLifeMax2));
            }
        }
    }
}
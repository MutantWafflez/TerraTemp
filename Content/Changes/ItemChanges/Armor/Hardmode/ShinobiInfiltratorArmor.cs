using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ShinobiInfiltratorHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkAltHead
        };

        public override float TemperatureResistanceChange => -0.05f;
    }

    public class ShinobiInfiltratorChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkAltShirt
        };

        public override float TemperatureResistanceChange => -0.05f;
    }

    public class ShinobiInfiltratorLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkAltPants
        };

        public override float TemperatureResistanceChange => -0.05f;
    }

    public class ShinobiInfiltratorArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.MonkAltHead
        };

        public override int ChestPieceID => ItemID.MonkAltShirt;

        public override int LegPieceID => ItemID.MonkAltPants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (DD2Event.Ongoing) {
                player.GetTempPlayer().temperatureChangeResist += 0.85f;
            }
        }
    }
}
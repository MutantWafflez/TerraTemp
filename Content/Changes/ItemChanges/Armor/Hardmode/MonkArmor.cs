using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class MonkHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkBrows
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.075f;
    }

    public class MonkChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkShirt
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.075f;
    }

    public class MonkLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkPants
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.075f;
    }

    public class MonkArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.MonkBrows
        };

        public override int ChestPieceID => ItemID.MonkShirt;

        public override int LegPieceID => ItemID.MonkPants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (DD2Event.Ongoing) {
                player.GetTempPlayer().temperatureChangeResist += 0.67f;
            }
        }
    }
}
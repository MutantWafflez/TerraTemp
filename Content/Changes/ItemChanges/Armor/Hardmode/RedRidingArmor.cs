using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;

using TerraTemp.Custom;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class RedRidingHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressAltHead
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class RedRidingChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressAltShirt
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class RedRidingLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressAltPants
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class RedRidingArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.HuntressAltHead
        };

        public override int ChestPieceID => ItemID.HuntressAltShirt;

        public override int LegPieceID => ItemID.HuntressAltPants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (DD2Event.Ongoing) {
                player.GetTempPlayer().temperatureChangeResist += 0.85f;
            }
        }
    }
}
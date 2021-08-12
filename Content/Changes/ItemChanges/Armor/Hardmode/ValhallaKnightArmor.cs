using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ValhallaKnightHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquireAltHead
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class ValhallaKnightChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquireAltShirt
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class ValhallaKnightLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquireAltPants
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class ValhallaKnightArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.SquireAltHead
        };

        public override int ChestPieceID => ItemID.SquireAltShirt;

        public override int LegPieceID => ItemID.SquireAltPants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (DD2Event.Ongoing) {
                player.GetTempPlayer().temperatureChangeResist += 0.85f;
            }
        }
    }
}
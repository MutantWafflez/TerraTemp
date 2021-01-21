using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class BeetleHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.BeetleHelmet
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class BeetleChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.BeetleScaleMail,
            ItemID.BeetleShell
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class BeetleLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.BeetleLeggings
        };

        public override float GetTemperatureResistanceChange(Player player) => -0.05f;
    }

    public class BeetleDefenseArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.BeetleHelmet,
        };

        public override int ChestPieceID => ItemID.BeetleShell;

        public override int LegPieceID => ItemID.BeetleLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetTempPlayer().temperatureChangeResist += (float)player.statDefense / 2f / 100f;
        }
    }

    public class BeetleOffenseArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.BeetleHelmet,
        };

        public override int ChestPieceID => ItemID.BeetleScaleMail;

        public override int LegPieceID => ItemID.BeetleLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetTempPlayer().temperatureChangeResist += (float)player.meleeCrit / 2f / 100f;
        }
    }
}
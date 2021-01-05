using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Content.Changes.EvilTempBiomes;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class ShadowHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ShadowHelmet,
            ItemID.AncientShadowHelmet
        };

        public override float TemperatureResistanceChange => 0.0125f;
    }

    public class ShadowChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ShadowScalemail,
            ItemID.AncientShadowScalemail
        };

        public override float TemperatureResistanceChange => 0.025f;
    }

    public class ShadowLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ShadowGreaves,
            ItemID.AncientShadowGreaves
        };

        public override float TemperatureResistanceChange => 0.0125f;
    }

    public class ShadowArmor : SetBonusChange {
        private readonly CorruptionClimate corruptionClimate = new CorruptionClimate();

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.ShadowHelmet
        };

        public override int ChestPieceID => ItemID.ShadowScalemail;

        public override int LegPieceID => ItemID.ShadowGreaves;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneCorrupt) {
                player.GetTempPlayer().temperatureChangeResist -= corruptionClimate.TemperatureResistanceModification;
            }
        }
    }

    public class AncientShadowArmor : SetBonusChange {
        private readonly CorruptionClimate corruptionClimate = new CorruptionClimate();

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.AncientShadowHelmet
        };

        public override int ChestPieceID => ItemID.AncientShadowScalemail;

        public override int LegPieceID => ItemID.AncientShadowGreaves;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneCorrupt) {
                player.GetTempPlayer().temperatureChangeResist -= corruptionClimate.TemperatureResistanceModification;
            }
        }
    }
}
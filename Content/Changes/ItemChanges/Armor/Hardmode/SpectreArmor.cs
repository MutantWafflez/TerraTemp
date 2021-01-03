using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class SpectreHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SpectreHood,
            ItemID.SpectreMask
        };

        public override float ColdComfortabilityChange => -4f;

        public override float HeatComfortabilityChange => -2f;
    }

    public class SpectreChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SpectreRobe
        };

        public override float ColdComfortabilityChange => -6f;

        public override float HeatComfortabilityChange => -4f;
    }

    public class SpectreLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SpectrePants
        };

        public override float ColdComfortabilityChange => -4f;

        public override float HeatComfortabilityChange => -2f;
    }

    public class SpectreArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.SpectreHood,
            ItemID.SpectreMask
        };

        public override int ChestPieceID => ItemID.SpectreRobe;

        public override int LegPieceID => ItemID.SpectrePants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.statMana < player.statManaMax2) {
                player.GetTempPlayer().temperatureChangeResist += 0.8f * (1f - ((float)player.statMana / (float)player.statManaMax2));
            }
        }
    }
}
using System.Collections.Generic;
using Terraria;
using Terraria.ID;

using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class SpectreHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SpectreHood,
            ItemID.SpectreMask
        };

        public override float GetColdComfortabilityChange(Player player) => -4f;

        public override float GetHeatComfortabilityChange(Player player) => -2f;
    }

    public class SpectreChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SpectreRobe
        };

        public override float GetColdComfortabilityChange(Player player) => -6f;

        public override float GetHeatComfortabilityChange(Player player) => -4f;
    }

    public class SpectreLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SpectrePants
        };

        public override float GetColdComfortabilityChange(Player player) => -4f;

        public override float GetHeatComfortabilityChange(Player player) => -2f;
    }

    public class SpectreArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.SpectreHood,
            ItemID.SpectreMask
        };

        public override int ChestPieceID => ItemID.SpectreRobe;

        public override int LegPieceID => ItemID.SpectrePants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.statMana < player.statManaMax2) {
                player.GetTempPlayer().temperatureChangeResist += 0.7f * (1f - ((float)player.statMana / (float)player.statManaMax2));
            }
        }
    }
}
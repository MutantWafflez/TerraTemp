using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {
    public class ChlorophyteHelmet : ItemChange {
        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ChlorophyteHelmet,
            ItemID.ChlorophyteMask,
            ItemID.ChlorophyteHeadgear
        };

        public override float GetColdComfortabilityChange(Player player) => 1f;

        public override float GetHeatComfortabilityChange(Player player) => -1f;
    }

    public class ChlorophyteChestplate : ItemChange {
        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ChlorophytePlateMail
        };

        public override float GetColdComfortabilityChange(Player player) => 2f;

        public override float GetHeatComfortabilityChange(Player player) => -2f;
    }

    public class ChlorophyteLeggings : ItemChange {
        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ChlorophyteGreaves
        };

        public override float GetColdComfortabilityChange(Player player) => 1f;

        public override float GetHeatComfortabilityChange(Player player) => -1f;
    }

    public class ChlorophyteArmor : SetBonusChange {
        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.ChlorophyteHelmet,
            ItemID.ChlorophyteMask,
            ItemID.ChlorophyteHeadgear
        };

        public override int ChestPieceID => ItemID.ChlorophytePlateMail;

        public override int LegPieceID => ItemID.ChlorophyteGreaves;

        public override void AdditionalSetBonusEffect(Player player) {
            HashSet<float> listofCrits = new HashSet<float>() {
                player.GetCritChance<MeleeDamageClass>(),
                player.GetCritChance<RangedDamageClass>(),
                player.GetCritChance<MagicDamageClass>(),
                player.GetCritChance<ThrowingDamageClass>()
            };
            player.GetTempPlayer().temperatureChangeResist += listofCrits.Max() / 100f;
        }
    }
}
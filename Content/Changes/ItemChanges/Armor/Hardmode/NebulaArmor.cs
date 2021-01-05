using Terraria.ID;
using System.Collections.Generic;
using TerraTemp.Content.Buffs.TempEffects;
using Terraria.ModLoader;
using Terraria;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class NebulaHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.NebulaHelmet
        };

        public override float HeatComfortabilityChange => -2f;
    }

    public class NebulaChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.NebulaBreastplate
        };

        public override float HeatComfortabilityChange => -3f;
    }

    public class NebulaLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.NebulaLeggings
        };

        public override float HeatComfortabilityChange => -2f;
    }

    public class NebulaArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.NebulaHelmet
        };

        public override int ChestPieceID => ItemID.NebulaBreastplate;

        public override int LegPieceID => ItemID.NebulaLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            TempPlayer tempPlayer = player.GetTempPlayer();
            if (tempPlayer.currentTemperature < tempPlayer.comfortableLow) {
                player.statDefense = (int)(player.statDefense + (2f * (tempPlayer.comfortableLow - tempPlayer.currentTemperature)));
                player.buffImmune[ModContent.BuffType<Shivering>()] = true;
                player.buffImmune[ModContent.BuffType<Hypothermia>()] = true;
            }
        }
    }
}
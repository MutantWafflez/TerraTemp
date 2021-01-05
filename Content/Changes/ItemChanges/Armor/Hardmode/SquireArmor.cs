﻿using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class SquireHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquireGreatHelm
        };

        public override float TemperatureResistanceChange => -0.075f;
    }

    public class SquireChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquirePlating
        };

        public override float TemperatureResistanceChange => -0.075f;
    }

    public class SquireLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquireGreaves
        };

        public override float TemperatureResistanceChange => -0.075f;
    }

    public class SquireArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.SquireGreatHelm
        };

        public override int ChestPieceID => ItemID.SquirePlating;

        public override int LegPieceID => ItemID.SquireGreaves;

        public override void AdditionalSetBonusEffect(Player player) {
            if (DD2Event.Ongoing) {
                player.GetTempPlayer().temperatureChangeResist += 0.67f;
            }
        }
    }
}
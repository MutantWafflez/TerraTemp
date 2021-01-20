using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class DarkArtistHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeAltHead
        };

        public override float TemperatureResistanceChange => -0.05f;
    }

    public class DarkArtistChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeAltShirt
        };

        public override float TemperatureResistanceChange => -0.05f;
    }

    public class DarkArtistLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeAltPants
        };

        public override float TemperatureResistanceChange => -0.05f;
    }

    public class DarkArtistArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.ApprenticeAltHead
        };

        public override int ChestPieceID => ItemID.ApprenticeAltShirt;

        public override int LegPieceID => ItemID.ApprenticeAltPants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (DD2Event.Ongoing) {
                player.GetTempPlayer().temperatureChangeResist += 0.85f;
            }
        }
    }
}
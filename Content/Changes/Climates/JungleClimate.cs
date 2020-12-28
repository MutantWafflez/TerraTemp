﻿using Terraria;

namespace TerraTemp.Content.Changes.TempBiomes {

    public class JungleClimate : Climate {
        public override float TemperatureModification => 12.5f;

        public override float HumidityModification => 0.34f;

        public override bool PlayerZoneBool(Player player) => player.ZoneJungle;
    }
}
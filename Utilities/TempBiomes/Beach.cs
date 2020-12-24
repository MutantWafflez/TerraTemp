﻿using Terraria;

namespace TerraTemp.Utilities.TempBiomes {

    public class Beach : TempBiome {
        public override float TemperatureModification => -2.5f;

        public override bool PlayerZoneBool(Player player) => player.ZoneBeach;
    }
}
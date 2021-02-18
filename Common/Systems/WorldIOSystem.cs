using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TerraTemp.Common.Systems {

    public class WorldIOSystem : ModSystem {

        public override TagCompound SaveWorldData() {
            return new TagCompound {
                {"temperatureDeviation", TerraTemp.dailyTemperatureDeviation },
                {"humidityDeviation", TerraTemp.dailyHumidityDeviation }
            };
        }

        public override void LoadWorldData(TagCompound tag) {
            TerraTemp.dailyTemperatureDeviation = tag.GetFloat("temperatureDeviation");
            TerraTemp.dailyHumidityDeviation = tag.GetFloat("humidityDeviation");
        }
    }
}
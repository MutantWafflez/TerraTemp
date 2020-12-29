using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TerraTemp {

    public class TempWorld : ModWorld {

        #region I/O

        public override TagCompound Save() {
            return new TagCompound {
                {"temperatureDeviation", TerraTemp.dailyTemperatureDeviation },
                {"humidityDeviation", TerraTemp.dailyHumidityDeviation }
            };
        }

        public override void Load(TagCompound tag) {
            TerraTemp.dailyTemperatureDeviation = tag.GetFloat("temperatureDeviation");
            TerraTemp.dailyHumidityDeviation = tag.GetFloat("humidityDeviation");
        }

        #endregion I/O
    }
}
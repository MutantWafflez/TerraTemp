using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TerraTemp {

    public class TempWorld : ModWorld {

        //Wind speeds should be completely reset on world gen. Don't want potentially hurricane level winds on day 1!
        public override void PostWorldGen() {
            Main.windSpeedSet = 0f;
            Main.windSpeed = 0f;
            Main.windSpeedSpeed = 0f;
            Main.windSpeedTemp = 0f;
        }

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
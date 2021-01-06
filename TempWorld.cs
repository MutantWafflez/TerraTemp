using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TerraTemp {

    public class TempWorld : ModWorld {

        #region World Creation

        //We want randomized values with temperature/humidity deviation when a world is first generated. Also, to avoid any extreme winds, we set Main.windSpeed to 0f;
        public override void PostWorldGen() {
            ModContent.GetInstance<TerraTemp>().NewDayStarted();
            Main.windSpeed = 0f;
        }

        #endregion

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
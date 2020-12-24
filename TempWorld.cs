using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TerraTemp {

    public class TempWorld : ModWorld {

        #region I/O

        public override TagCompound Save() {
            return new TagCompound {
                {"temperatureDeviation", TerraTemp.dailyTemperatureDeviation }
            };
        }

        public override void Load(TagCompound tag) {
            TerraTemp.dailyTemperatureDeviation = tag.GetFloat("temperatureDeviation");
        }

        #endregion
    }
}
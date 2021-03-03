using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraTemp.Custom;

namespace TerraTemp {

    public class TempWorld : ModWorld {

        //Here we "normalize" a few things so the first few days in a world aren't extremely painful. We reset wind speeds and normalize the first two days of temperature and humidity.
        public override void PostWorldGen() {
            Main.windSpeedSet = 0f;
            Main.windSpeed = 0f;
            Main.windSpeedSpeed = 0f;
            Main.windSpeedTemp = 0f;
            for (int i = 0; i < 3; i++) {
                TerraTemp.Instance.NewDayStarted();
            }
        }

        #region I/O

        public override TagCompound Save() {
            return new TagCompound {
                {"temperatureDeviations", TerraTemp.weeklyTemperatureDeviations.ToList() },
                {"humidityDeviations", TerraTemp.weeklyHumidityDeviations.ToList() }
            };
        }

        public override void Load(TagCompound tag) {
            TerraTemp.weeklyTemperatureDeviations = tag.GetList<float>("temperatureDeviations").ToArray();
            TerraTemp.weeklyHumidityDeviations = tag.GetList<float>("humidityDeviations").ToArray();

            //For any legacy loading, swap over to the new weekly system (by generating whole new arrays)
            if (!TerraTemp.weeklyTemperatureDeviations.Any()) {
                TerraTemp.weeklyTemperatureDeviations = new float[] {
                    TempUtilities.GenerateTemperatureDeviation(),
                    TempUtilities.GenerateTemperatureDeviation(),
                    TempUtilities.GenerateTemperatureDeviation(),
                    TempUtilities.GenerateTemperatureDeviation(),
                    TempUtilities.GenerateTemperatureDeviation() };
            }
            if (!TerraTemp.weeklyHumidityDeviations.Any()) {
                TerraTemp.weeklyHumidityDeviations = new float[] {
                    TempUtilities.GenerateHumidityDeviation(),
                    TempUtilities.GenerateHumidityDeviation(),
                    TempUtilities.GenerateHumidityDeviation(),
                    TempUtilities.GenerateHumidityDeviation(),
                    TempUtilities.GenerateHumidityDeviation() };
            }
        }

        #endregion I/O
    }
}
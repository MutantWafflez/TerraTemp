using System.Linq;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraTemp.Custom;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Common.Systems {

    /// <summary>
    /// System thats handles all I/O for world saving/loading.
    /// </summary>
    public class IOSystem : ModSystem {

        public override TagCompound SaveWorldData() {
            return new TagCompound {
                {"temperatureDeviations", WeeklyTemperatureSystem.weeklyTemperatureDeviations.ToList() },
                {"humidityDeviations", WeeklyTemperatureSystem.weeklyHumidityDeviations.ToList() }
            };
        }

        public override void LoadWorldData(TagCompound tag) {
            WeeklyTemperatureSystem.weeklyTemperatureDeviations = tag.GetList<float>("temperatureDeviations").ToArray();
            WeeklyTemperatureSystem.weeklyHumidityDeviations = tag.GetList<float>("humidityDeviations").ToArray();

            //For any legacy loading, swap over to the new weekly system (by generating whole new arrays)
            if (!WeeklyTemperatureSystem.weeklyTemperatureDeviations.Any()) {
                WeeklyTemperatureSystem.weeklyTemperatureDeviations = new float[] {
                    MathUtilities.GenerateTemperatureDeviation(),
                    MathUtilities.GenerateTemperatureDeviation(),
                    MathUtilities.GenerateTemperatureDeviation(),
                    MathUtilities.GenerateTemperatureDeviation(),
                    MathUtilities.GenerateTemperatureDeviation() };
            }
            if (!WeeklyTemperatureSystem.weeklyHumidityDeviations.Any()) {
                WeeklyTemperatureSystem.weeklyHumidityDeviations = new float[] {
                    MathUtilities.GenerateHumidityDeviation(),
                    MathUtilities.GenerateHumidityDeviation(),
                    MathUtilities.GenerateHumidityDeviation(),
                    MathUtilities.GenerateHumidityDeviation(),
                    MathUtilities.GenerateHumidityDeviation() };
            }
        }
    }
}
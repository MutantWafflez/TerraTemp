using Terraria;
using Terraria.ModLoader;

namespace TerraTemp.Common.Systems {

    /// <summary>
    /// System that handles anything having to do with world generation.
    /// </summary>
    public class WorldGenSystem : ModSystem {

        //Here we "normalize" a few things so the first few days in a world aren't extremely painful. We reset wind speeds and normalize the first two days of temperature and humidity.
        public override void PostWorldGen() {
            WeeklyTemperatureSystem tempSystem = ModContent.GetInstance<WeeklyTemperatureSystem>();

            Main.windPhysicsStrength = 0f;
            Main.windSpeedCurrent = 0f;
            Main.windSpeedTarget = 0f;
            Main.windCounter = 0;
            for (int i = 0; i < 3; i++) {
                tempSystem.NewDayStarted();
            }
        }
    }
}
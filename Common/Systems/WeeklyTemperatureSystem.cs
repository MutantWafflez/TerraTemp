using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Custom;
using TerraTemp.Custom.Enums;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Common.Systems {

    /// <summary>
    /// System that handles the weekly temperature/humidity deviation within the mod.
    /// </summary>
    public class WeeklyTemperatureSystem : ModSystem {

        /// <summary>
        /// The values for all of the temperatures deviations for a given "week." Temperature
        /// deviations determine how potent the effects of the day/night are.
        /// </summary>
        public static float[] weeklyTemperatureDeviations = { 1f, 1f, 1f, 1f, 1f };

        /// <summary>
        /// The values for all of the humidity deviations for a given "week." Humidity deviations
        /// determine how much more additional humidity is added to each player, regardless of climate.
        /// </summary>
        public static float[] weeklyHumidityDeviations = { 0f, 0f, 0f, 0f, 0f };

        public override void PostUpdateTime() {
            if (Main.time >= 32400.0 && !Main.dayTime && (!Main.gameMenu || Main.netMode == NetmodeID.Server)) {
                NewDayStarted();
            }
        }

        public void NewDayStarted() {
            //Temperature/Humidity Deviation
            if (Main.netMode == NetmodeID.Server) {
                weeklyTemperatureDeviations.DestructivelyShiftLeftOne();
                weeklyTemperatureDeviations[^1] = MathUtilities.GenerateTemperatureDeviation();
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)PacketID.WeeklyTemperatureDeviations);
                for (int i = 0; i < weeklyTemperatureDeviations.Length; i++) {
                    packet.Write(weeklyTemperatureDeviations[i]);
                }
                packet.Send();

                weeklyHumidityDeviations.DestructivelyShiftLeftOne();
                weeklyHumidityDeviations[weeklyTemperatureDeviations.Length - 1] = MathUtilities.GenerateHumidityDeviation();
                packet = Mod.GetPacket();
                packet.Write((byte)PacketID.WeeklyHumidityDeviations);
                for (int i = 0; i < weeklyHumidityDeviations.Length; i++) {
                    packet.Write(weeklyHumidityDeviations[i]);
                }
                packet.Send();
            }
            else if (Main.netMode == NetmodeID.SinglePlayer) {
                weeklyTemperatureDeviations.DestructivelyShiftLeftOne();
                weeklyTemperatureDeviations[^1] = MathUtilities.GenerateTemperatureDeviation();
                weeklyHumidityDeviations.DestructivelyShiftLeftOne();
                weeklyHumidityDeviations[weeklyTemperatureDeviations.Length - 1] = MathUtilities.GenerateHumidityDeviation();
            }
        }
    }
}
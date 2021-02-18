using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraTemp.Custom.Enums;

namespace TerraTemp.Common.Systems {

    public class UpdateTimeSystem : ModSystem {

        public override void PreUpdateTime() {
            if (Main.time >= 32400.0 && !Main.dayTime && (!Main.gameMenu || Main.netMode == NetmodeID.Server)) {
                NewDayStarted();
            }
        }

        public void NewDayStarted() {
            //Temperature/Humidity Deviation
            if (Main.netMode == NetmodeID.Server) {
                TerraTemp.dailyTemperatureDeviation = Main.rand.NextFloat(0.33f, 1.67f);
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)PacketID.DailyTemperatureDeviation);
                packet.Write(TerraTemp.dailyTemperatureDeviation);
                packet.Send();

                TerraTemp.dailyHumidityDeviation = Main.rand.NextFloat(-0.1f, 0.75f);
                packet = Mod.GetPacket();
                packet.Write((byte)PacketID.DailyHumidityDeviation);
                packet.Write(TerraTemp.dailyHumidityDeviation);
                packet.Send();
            }
            else if (Main.netMode == NetmodeID.SinglePlayer) {
                TerraTemp.dailyTemperatureDeviation = Main.rand.NextFloat(0.33f, 1.67f);
                TerraTemp.dailyHumidityDeviation = Main.rand.NextFloat(-0.1f, 0.75f);
            }
        }
    }
}
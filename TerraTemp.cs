using log4net;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Common.Systems;
using TerraTemp.Custom.Enums;

namespace TerraTemp {

    /// <summary>
    /// The Mod. Has only very basic properties and fields for the very core of the mod, as well as
    /// handles the Packets. If you're looking for the actual content that used to be in this class,
    /// check the Systems Folder within the Common Folder.
    /// </summary>
    public class TerraTemp : Mod {

        /// <summary>
        /// The string of the directory for all of the miscellaneous textures for TerraTemp.
        /// </summary>
        public const string TextureDirectory = nameof(TerraTemp) + "/Assets/Sprites/";

        /// <summary>
        /// Logger class for TerraTemp.
        /// </summary>
        internal static ILog Logging = LogManager.GetLogger("TerraTemp");

        public override void HandlePacket(BinaryReader reader, int whoAmI) {
            PacketID packetMessage = (PacketID)reader.ReadByte();
            switch (packetMessage) {
                case PacketID.WeeklyTemperatureDeviations:
                    if (Main.netMode == NetmodeID.MultiplayerClient) {
                        for (int i = 0; i < WeeklyTemperatureSystem.weeklyTemperatureDeviations.Length; i++) {
                            WeeklyTemperatureSystem.weeklyTemperatureDeviations[i] = reader.ReadSingle();
                        }
                    }
                    break;

                case PacketID.WeeklyHumidityDeviations:
                    if (Main.netMode == NetmodeID.MultiplayerClient) {
                        for (int i = 0; i < WeeklyTemperatureSystem.weeklyHumidityDeviations.Length; i++) {
                            WeeklyTemperatureSystem.weeklyHumidityDeviations[i] = reader.ReadSingle();
                        }
                    }
                    break;

                case PacketID.RequestServerTemperatureValues:
                    if (Main.netMode == NetmodeID.Server) {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)PacketID.ReceiveServerTemperatureValues);
                        for (int i = 0; i < WeeklyTemperatureSystem.weeklyTemperatureDeviations.Length; i++) {
                            packet.Write(WeeklyTemperatureSystem.weeklyTemperatureDeviations[i]);
                        }
                        for (int i = 0; i < WeeklyTemperatureSystem.weeklyHumidityDeviations.Length; i++) {
                            packet.Write(WeeklyTemperatureSystem.weeklyHumidityDeviations[i]);
                        }
                        packet.Send(whoAmI);
                    }
                    break;

                case PacketID.ReceiveServerTemperatureValues:
                    if (Main.netMode == NetmodeID.MultiplayerClient) {
                        for (int i = 0; i < WeeklyTemperatureSystem.weeklyTemperatureDeviations.Length; i++) {
                            WeeklyTemperatureSystem.weeklyTemperatureDeviations[i] = reader.ReadSingle();
                        }
                        for (int i = 0; i < WeeklyTemperatureSystem.weeklyHumidityDeviations.Length; i++) {
                            WeeklyTemperatureSystem.weeklyHumidityDeviations[i] = reader.ReadSingle();
                        }
                    }
                    break;

                default:
                    Logging.Error($"Message of ID type {packetMessage} not found!");
                    break;
            }
        }

        public override void PostAddRecipes() {
            ModContent.GetInstance<ContentListSystem>().HandleStatInheritance();
        }
    }
}
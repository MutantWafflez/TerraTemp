using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Changes;
using TerraTemp.ID;
using TerraTemp.Utilities;

namespace TerraTemp {

    public class TerraTemp : Mod {
        public static List<Climate> climates;
        public static List<EvilClimate> evilClimates;
        public static List<EventChange> eventChanges;

        public static List<ItemChange> itemChanges;
        public static List<SetBonusChange> setBonusChanges;
        public static List<BuffChange> buffChanges;

        public static float? dailyTemperatureDeviation = 1f;
        public static float dailyHumidityDeviation = 0f;

        #region Loading Overrides

        public override void PostSetupContent() {
            foreach (Type type in TempUtilities.GetAllChildrenOfClass<Climate>()) {
                climates.Add((Climate)Activator.CreateInstance(type));
            }

            foreach (Type type in TempUtilities.GetAllChildrenOfClass<EvilClimate>()) {
                evilClimates.Add((EvilClimate)Activator.CreateInstance(type));
            }

            foreach (Type type in TempUtilities.GetAllChildrenOfClass<EventChange>()) {
                eventChanges.Add((EventChange)Activator.CreateInstance(type));
            }

            foreach (Type type in TempUtilities.GetAllChildrenOfClass<ItemChange>()) {
                itemChanges.Add((ItemChange)Activator.CreateInstance(type));
            }

            foreach (Type type in TempUtilities.GetAllChildrenOfClass<SetBonusChange>()) {
                setBonusChanges.Add((SetBonusChange)Activator.CreateInstance(type));
            }

            foreach (Type type in TempUtilities.GetAllChildrenOfClass<BuffChange>()) {
                buffChanges.Add((BuffChange)Activator.CreateInstance(type));
            }
        }

        public override void Load() {
            climates = new List<Climate>();
            evilClimates = new List<EvilClimate>();
            eventChanges = new List<EventChange>();
            itemChanges = new List<ItemChange>();
            setBonusChanges = new List<SetBonusChange>();
            buffChanges = new List<BuffChange>();
        }

        public override void Unload() {
            climates = null;
            evilClimates = null;
            eventChanges = null;
            itemChanges = null;
            setBonusChanges = null;
            buffChanges = null;
            dailyTemperatureDeviation = null;
        }

        #endregion Loading Overrides

        #region Temperature Deviation

        public override void MidUpdateDustTime() {
            if (Main.time >= 32400.0 && !Main.dayTime && !Main.gameMenu) {
                NewDayStarted();
            }
        }

        #endregion Temperature Deviation

        #region Packet Handling

        public override void HandlePacket(BinaryReader reader, int whoAmI) {
            PacketID packetMessage = (PacketID)reader.ReadByte();
            switch (packetMessage) {
                case PacketID.DailyTemperatureDeviation:
                    dailyTemperatureDeviation = reader.ReadSingle();
                    break;

                case PacketID.DailyHumidityDeviation:
                    dailyHumidityDeviation = reader.ReadSingle();
                    break;

                default:
                    Logger.Error($"Message of ID type {packetMessage} not found!");
                    break;
            }
        }

        #endregion Packet Handling

        #region Custom Methods

        public void NewDayStarted() {
            if (Main.netMode == NetmodeID.Server) {
                dailyTemperatureDeviation = Main.rand.NextFloat(0.33f, 1.67f);
                ModPacket packet = GetPacket();
                packet.Write((byte)PacketID.DailyTemperatureDeviation);
                packet.Write((float)dailyTemperatureDeviation);
                packet.Send();

                dailyHumidityDeviation = Main.rand.NextFloat(-0.1f, 0.75f);
                packet = GetPacket();
                packet.Write((byte)PacketID.DailyHumidityDeviation);
                packet.Write(dailyHumidityDeviation);
                packet.Send();
            }
            else if (Main.netMode == NetmodeID.SinglePlayer) {
                dailyTemperatureDeviation = Main.rand.NextFloat(0.33f, 1.67f);
                dailyHumidityDeviation = Main.rand.NextFloat(-0.1f, 0.75f);
            }
        }

        #endregion
    }
}
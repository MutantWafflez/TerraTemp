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

        /// <summary>
        /// A list of ALL newly added Climates. If you wish to add or otherwise remove a given
        /// Climate, search through this List with LINQ or any other method that is preferred.
        /// </summary>
        public static List<Climate> climates;

        /// <summary>
        /// A list of ALL newly added Evil Climates. If you wish to add or otherwise remove a given
        /// Evil Climate, search through this List with LINQ or any other method that is preferred.
        /// </summary>
        public static List<EvilClimate> evilClimates;

        /// <summary>
        /// A list of ALL newly added Event Changes. If you wish to add or otherwise remove a given
        /// Event Change, search through this List with LINQ or any other method that is preferred.
        /// </summary>
        public static List<EventChange> eventChanges;

        /// <summary>
        /// A list of ALL newly added Item Changes. If you wish to add or otherwise remove a given
        /// Item Change, search through this List with LINQ or any other method that is preferred.
        /// </summary>
        public static List<ItemChange> itemChanges;

        /// <summary>
        /// A list of ALL newly added Set Bonus Changes. If you wish to add or otherwise remove a
        /// given Set Bonus Change, search through this List with LINQ or any other method that is preferred.
        /// </summary>
        public static List<SetBonusChange> setBonusChanges;

        /// <summary>
        /// A list of ALL newly added Buff Changes. If you wish to add or otherwise remove a given
        /// Buff Change, search through this List with LINQ or any other method that is preferred.
        /// </summary>
        public static List<BuffChange> buffChanges;

        /// <summary>
        /// A list of ALL newly added Loot Changes. If you wish to add or otherwise remove a given
        /// Loot Change, search through this List with LINQ or any other method that is preferred.
        /// </summary>
        public static List<NPCLootChange> lootChanges;

        /// <summary>
        /// A value that is randomized daily that determines how hot it will get during the day and
        /// how cold it will get during the night.
        /// </summary>
        public static float dailyTemperatureDeviation = 1f;

        /// <summary>
        /// A value that is randomized daily that adds (or potentially removes) Relative Humidity to
        /// the entire world for that day.
        /// </summary>
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

            foreach (Type type in TempUtilities.GetAllChildrenOfClass<NPCLootChange>()) {
                lootChanges.Add((NPCLootChange)Activator.CreateInstance(type));
            }
        }

        public override void Load() {
            climates = new List<Climate>();
            evilClimates = new List<EvilClimate>();
            eventChanges = new List<EventChange>();
            itemChanges = new List<ItemChange>();
            setBonusChanges = new List<SetBonusChange>();
            buffChanges = new List<BuffChange>();
            lootChanges = new List<NPCLootChange>();
        }

        public override void Unload() {
            climates = null;
            evilClimates = null;
            eventChanges = null;
            itemChanges = null;
            setBonusChanges = null;
            buffChanges = null;
            lootChanges = null;
        }

        #endregion Loading Overrides

        #region Update Overrides

        public override void MidUpdateDustTime() {
            if (Main.time >= 32400.0 && !Main.dayTime && (!Main.gameMenu || Main.netMode == NetmodeID.Server)) {
                NewDayStarted();
            }
        }

        #endregion

        #region Packet Handling

        public override void HandlePacket(BinaryReader reader, int whoAmI) {
            PacketID packetMessage = (PacketID)reader.ReadByte();
            switch (packetMessage) {
                case PacketID.DailyTemperatureDeviation:
                    if (Main.netMode == NetmodeID.MultiplayerClient) {
                        dailyTemperatureDeviation = reader.ReadSingle();
                    }
                    break;

                case PacketID.DailyHumidityDeviation:
                    if (Main.netMode == NetmodeID.MultiplayerClient) {
                        dailyHumidityDeviation = reader.ReadSingle();
                    }
                    break;

                case PacketID.RequestServerTemperatureValues:
                    if (Main.netMode == NetmodeID.Server) {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)PacketID.ReceiveServerTemperatureValues);
                        packet.Write(dailyTemperatureDeviation);
                        packet.Write(dailyHumidityDeviation);
                        packet.Send(whoAmI);
                    }
                    break;

                case PacketID.ReceiveServerTemperatureValues:
                    if (Main.netMode == NetmodeID.MultiplayerClient) {
                        dailyTemperatureDeviation = reader.ReadSingle();
                        dailyHumidityDeviation = reader.ReadSingle();
                    }
                    break;

                default:
                    Logger.Error($"Message of ID type {packetMessage} not found!");
                    break;
            }
        }

        #endregion Packet Handling

        #region Custom Methods

        public void NewDayStarted() {
            //Temperature/Humidity Deviation
            if (Main.netMode == NetmodeID.Server) {
                dailyTemperatureDeviation = Main.rand.NextFloat(0.33f, 1.67f);
                ModPacket packet = GetPacket();
                packet.Write((byte)PacketID.DailyTemperatureDeviation);
                packet.Write(dailyTemperatureDeviation);
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
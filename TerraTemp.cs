using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Changes;
using TerraTemp.ID;

namespace TerraTemp {

    public class TerraTemp : Mod {
        public static List<TempBiome> tempBiomes;
        public static List<EvilTempBiome> evilTempBiomes;

        public static List<ItemChange> itemChanges;
        public static List<SetBonusChange> setBonusChanges;
        public static List<BuffChange> buffChanges;

        public static float? dailyTemperatureDeviation = 1f;

        #region Loading Overrides

        public override void PostSetupContent() {
            List<Type> tempBiomeTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(TempBiome)) && !type.IsAbstract).ToList();
            tempBiomes = new List<TempBiome>();
            foreach (Type type in tempBiomeTypes) {
                tempBiomes.Add((TempBiome)Activator.CreateInstance(type));
            }

            List<Type> evilTempBiomeTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(EvilTempBiome)) && !type.IsAbstract).ToList();
            evilTempBiomes = new List<EvilTempBiome>();
            foreach (Type type in evilTempBiomeTypes) {
                evilTempBiomes.Add((EvilTempBiome)Activator.CreateInstance(type));
            }

            List<Type> itemChangeTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(ItemChange)) && !type.IsAbstract).ToList();
            itemChanges = new List<ItemChange>();
            foreach (Type type in itemChangeTypes) {
                itemChanges.Add((ItemChange)Activator.CreateInstance(type));
            }

            List<Type> setBonusChangeTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(SetBonusChange)) && !type.IsAbstract).ToList();
            setBonusChanges = new List<SetBonusChange>();
            foreach (Type type in setBonusChangeTypes) {
                setBonusChanges.Add((SetBonusChange)Activator.CreateInstance(type));
            }

            List<Type> buffChangeTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(BuffChange)) && !type.IsAbstract).ToList();
            buffChanges = new List<BuffChange>();
            foreach (Type type in buffChangeTypes) {
                buffChanges.Add((BuffChange)Activator.CreateInstance(type));
            }
        }

        public override void Unload() {
            tempBiomes = null;
            evilTempBiomes = null;
            itemChanges = null;
            setBonusChanges = null;
            buffChanges = null;
            dailyTemperatureDeviation = null;
        }

        #endregion Loading Overrides

        #region Temperature Deviation

        public override void MidUpdateDustTime() {
            if (Main.netMode == NetmodeID.Server) {
                if (Main.time >= 32400.0 && !Main.dayTime && !Main.gameMenu) {
                    dailyTemperatureDeviation = Main.rand.NextFloat(0.33f, 1.67f);
                    ModPacket packet = GetPacket();
                    packet.Write((byte)PacketID.DailyTemperatureDeviation);
                    packet.Write((float)dailyTemperatureDeviation);
                    packet.Send();
                }
            }
            else if (Main.netMode == NetmodeID.SinglePlayer) {
                if (Main.time >= 32400.0 && !Main.dayTime && !Main.gameMenu) {
                    dailyTemperatureDeviation = Main.rand.NextFloat(0.33f, 1.67f);
                }
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

                default:
                    Logger.Error($"Message of ID type {packetMessage} not found!");
                    break;
            }
        }

        #endregion Packet Handling
    }
}
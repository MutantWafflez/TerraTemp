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
        public static List<Climate> climates;
        public static List<EvilClimate> evilClimates;

        public static List<ItemChange> itemChanges;
        public static List<SetBonusChange> setBonusChanges;
        public static List<BuffChange> buffChanges;

        public static float? dailyTemperatureDeviation = 1f;

        #region Loading Overrides

        public override void PostSetupContent() {
            List<Type> climateTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(Climate)) && !type.IsAbstract).ToList();
            foreach (Type type in climateTypes) {
                climates.Add((Climate)Activator.CreateInstance(type));
            }

            List<Type> evilClimateTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(EvilClimate)) && !type.IsAbstract).ToList();
            foreach (Type type in evilClimateTypes) {
                evilClimates.Add((EvilClimate)Activator.CreateInstance(type));
            }

            List<Type> itemChangeTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(ItemChange)) && !type.IsAbstract).ToList();
            foreach (Type type in itemChangeTypes) {
                itemChanges.Add((ItemChange)Activator.CreateInstance(type));
            }

            List<Type> setBonusChangeTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(SetBonusChange)) && !type.IsAbstract).ToList();
            foreach (Type type in setBonusChangeTypes) {
                setBonusChanges.Add((SetBonusChange)Activator.CreateInstance(type));
            }

            List<Type> buffChangeTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(BuffChange)) && !type.IsAbstract).ToList();
            foreach (Type type in buffChangeTypes) {
                buffChanges.Add((BuffChange)Activator.CreateInstance(type));
            }
        }

        public override void Load() {
            climates = new List<Climate>();
            evilClimates = new List<EvilClimate>();
            itemChanges = new List<ItemChange>();
            setBonusChanges = new List<SetBonusChange>();
            buffChanges = new List<BuffChange>();
        }

        public override void Unload() {
            climates = null;
            evilClimates = null;
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
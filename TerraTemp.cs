using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Common.Systems;
using TerraTemp.Content.Changes;
using TerraTemp.Custom;
using TerraTemp.Custom.Enums;

namespace TerraTemp {

    public class TerraTemp : Mod {

        #region Content Lists

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
        /// A list of ALL newly added Item Holdout Changes. If you wish to add or otherwise remove a
        /// given Item Holdout Change, search through this List with LINQ or any other method that
        /// is preferred.
        /// </summary>
        public static List<ItemHoldoutChange> itemHoldoutChanges;

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
        /// A list of ALL newly added Bag Changes. If you wish to add or otherwise remove a given
        /// Bag Change, search through this List with LINQ or any other method that is preferred.
        /// </summary>
        public static List<BagChange> bagChanges;

        /// <summary>
        /// A list of ALL newly added Tile Adjacency Changes. If you wish to add or otherwise remove
        /// a given Tile Adjacency Change, search through this List with LINQ or any other method
        /// that is preferred.
        /// </summary>
        public static List<AdjacencyChange> adjacencyChanges;

        /// <summary>
        /// Hashset of all NPCs that are detonated as "warm" that will determine whether or not
        /// these NPCs will increase a player's temperature slightly upon hitting them.
        /// </summary>
        public static HashSet<int> warmNPCTypes;

        #endregion

        /// <summary>
        /// Logger class for TerraTemp.
        /// </summary>
        internal static ILog Logging = LogManager.GetLogger("TerraTemp");

        public static TerraTemp Instance { get; private set; }

        public TerraTemp() {
            Instance = this;

            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        #region Loading Overrides

        public override void Load() {

            #region List Initialization

            climates = new List<Climate>();
            evilClimates = new List<EvilClimate>();
            eventChanges = new List<EventChange>();
            itemChanges = new List<ItemChange>();
            itemHoldoutChanges = new List<ItemHoldoutChange>();
            setBonusChanges = new List<SetBonusChange>();
            buffChanges = new List<BuffChange>();
            lootChanges = new List<NPCLootChange>();
            bagChanges = new List<BagChange>();
            adjacencyChanges = new List<AdjacencyChange>();
            warmNPCTypes = new HashSet<int>();

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

            foreach (Type type in TempUtilities.GetAllChildrenOfClass<ItemHoldoutChange>()) {
                itemHoldoutChanges.Add((ItemHoldoutChange)Activator.CreateInstance(type));
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

            foreach (Type type in TempUtilities.GetAllChildrenOfClass<BagChange>()) {
                bagChanges.Add((BagChange)Activator.CreateInstance(type));
            }

            foreach (Type type in TempUtilities.GetAllChildrenOfClass<AdjacencyChange>()) {
                adjacencyChanges.Add((AdjacencyChange)Activator.CreateInstance(type));
            }

            warmNPCTypes = FillWarmNPCHashSet();

            #endregion
        }

        public override void Unload() {
            climates = null;
            evilClimates = null;
            eventChanges = null;
            itemChanges = null;
            itemHoldoutChanges = null;
            setBonusChanges = null;
            buffChanges = null;
            lootChanges = null;
            bagChanges = null;
            adjacencyChanges = null;
            warmNPCTypes = null;

            Instance = null;
        }

        #endregion Loading Overrides

        #region Packet Handling

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
                    Logger.Error($"Message of ID type {packetMessage} not found!");
                    break;
            }
        }

        #endregion Packet Handling

        #region Custom Methods

        public HashSet<int> FillWarmNPCHashSet() {
            HashSet<int> placeholderHashSet = new HashSet<int>() {
                NPCID.BlazingWheel,
                NPCID.FireImp,
                NPCID.Hellbat,
                NPCID.LavaSlime,
                NPCID.MeteorHead,
                NPCID.DiabolistRed,
                NPCID.DiabolistWhite,
                NPCID.HellArmoredBones,
                NPCID.HellArmoredBonesMace,
                NPCID.HellArmoredBonesSpikeShield,
                NPCID.HellArmoredBonesSword,
                NPCID.Lavabat,
                NPCID.SolarCorite,
                NPCID.SolarCrawltipedeHead,
                NPCID.SolarCrawltipedeBody,
                NPCID.SolarCrawltipedeTail,
                NPCID.SolarDrakomire,
                NPCID.SolarDrakomireRider,
                NPCID.SolarSpearman,
                NPCID.SolarSolenian,
                NPCID.SolarSroller,
                NPCID.LunarTowerSolar
            };
            return placeholderHashSet;
        }

        #endregion
    }
}
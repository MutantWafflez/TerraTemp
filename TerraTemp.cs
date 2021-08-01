using log4net;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using TerraTemp.Common.Systems;
using TerraTemp.Content.Buffs.TempEffects;
using TerraTemp.Content.Changes;
using TerraTemp.Content.ModChanges;
using TerraTemp.Custom;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;
using TerraTemp.Custom.Enums;
using TerraTemp.Custom.Patches;

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

        #region Mod Compatability Fields

        /// <summary>
        /// A list of all of the mods that have official compatability that have been enabled
        /// alongside TerraTemp.
        /// </summary>
        public static List<ReflectionMod> activeCompatibleMods;

        /// <summary>
        /// A list of ALL compatible mod events. If you wish to add or otherwise remove a given mod
        /// event, search through this List with LINQ or any other method that is preferred.
        /// </summary>
        public static List<ModEvent> modEvents;

        /// <summary>
        /// A list of ALL compatible mod climates (biomes). If you wish to add or otherwise remove a
        /// given mod climate, search through this List with LINQ or any other method that is preferred.
        /// </summary>
        public static List<ModClimate> modClimates;

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

        //Handles all of the Accessory Inheritence for automated cross-mod compatability.
        public override void PostAddRecipes() {
            //Step 1: Get all items that can be crafted from items that allow inheritence
            List<DerivedItemChange> placeholderItemChanges = new List<DerivedItemChange>();
            foreach (ItemChange itemChange in itemChanges) {
                if (itemChange.DerivedItemsProvideEffects && itemChange.GetType() != typeof(DerivedItemChange)) {
                    foreach (int itemID in itemChange.AppliedItemIDs) {
                        HashSet<int> derivedItems = TempUtilities.DeepRecipeSearch(itemID);
                        foreach (int derivedID in derivedItems) {
                            placeholderItemChanges.Add(new DerivedItemChange(derivedID, itemChange));
                        }
                    }
                }
            }

            //Step 2: Take all of the inherited items and merge any duplicates.
            int mergeCount;
            do {
                mergeCount = 0;
                placeholderItemChanges.Sort((changeOne, changeTwo) => changeOne.appliedItemID.CompareTo(changeTwo.appliedItemID));
                for (int i = 0; i < placeholderItemChanges.Count; i++) {
                    if (i + 1 < placeholderItemChanges.Count) {
                        if (placeholderItemChanges[i].Merge(placeholderItemChanges[i + 1])) {
                            placeholderItemChanges.RemoveAt(i + 1);
                            mergeCount++;
                        }
                    }
                }
            }
            while (mergeCount != 0);

            //Step 3: Add all new inherited items to the end of the ItemChanges list.
            foreach (DerivedItemChange derivedItemChange in placeholderItemChanges) {
                itemChanges.Add(derivedItemChange);
            }
        }

        public override void PostSetupContent() {
            //Mod Compatability Loading
            foreach (Type type in TempUtilities.GetAllChildrenOfClass<ReflectionMod>()) {
                string returnedInternalName = type.GetCustomAttribute<InternalModName>().name;
                if (returnedInternalName != null) {
                    Mod returnedMod = ModLoader.GetMod(returnedInternalName);
                    if (returnedMod != null) {
                        activeCompatibleMods.Add((ReflectionMod)Activator.CreateInstance(type, new object[] { returnedMod }));
                    }
                }
                else {
                    throw new Exception("Reflection Mod of type " + type.Name + " did not have an InternalModName Attribute that returned a non-null value.");
                }
            }

            foreach (Type modEventType in TempUtilities.GetAllChildrenOfClass<ModEvent>()) {
                Type returnedType = modEventType.GetCustomAttribute<PertainedMod>().pertainedMod;
                if (returnedType != null) {
                    foreach (ReflectionMod reflectionMod in activeCompatibleMods) {
                        if (reflectionMod.GetType() == returnedType) {
                            modEvents.Add((ModEvent)Activator.CreateInstance(modEventType, new object[] { reflectionMod }));
                            break;
                        }
                    }
                }
                else {
                    throw new Exception("Mod Event Type " + modEventType.Name + " did not have a PertainedMod Attributed that returned a non-null value.");
                }
            }

            foreach (Type modClimateType in TempUtilities.GetAllChildrenOfClass<ModClimate>()) {
                Type returnedType = modClimateType.GetCustomAttribute<PertainedMod>().pertainedMod;
                if (returnedType != null) {
                    foreach (ReflectionMod reflectionMod in activeCompatibleMods) {
                        if (reflectionMod.GetType() == returnedType) {
                            modClimates.Add((ModClimate)Activator.CreateInstance(modClimateType, new object[] { reflectionMod }));
                            break;
                        }
                    }
                }
                else {
                    throw new Exception("Mod Climate Type " + modClimateType.Name + " did not have a PertainedMod Attributed that returned a non-null value.");
                }
            }

            ModILManager.LoadILEdits();
        }

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

            activeCompatibleMods = new List<ReflectionMod>();
            modEvents = new List<ModEvent>();
            modClimates = new List<ModClimate>();

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

            activeCompatibleMods = null;
            modEvents = null;
            modClimates = null;

            ModILManager.UnloadILEdits();

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
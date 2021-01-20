using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Buffs.TempEffects;
using TerraTemp.Content.Changes;
using TerraTemp.Custom;
using TerraTemp.ID;

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

        #endregion

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

        public static TerraTemp TerraTempInstance { get; private set; }

        public TerraTemp() {
            TerraTempInstance = this;

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

        public override void Load() {
            climates = new List<Climate>();
            evilClimates = new List<EvilClimate>();
            eventChanges = new List<EventChange>();
            itemChanges = new List<ItemChange>();
            setBonusChanges = new List<SetBonusChange>();
            buffChanges = new List<BuffChange>();
            lootChanges = new List<NPCLootChange>();
            bagChanges = new List<BagChange>();
            adjacencyChanges = new List<AdjacencyChange>();

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

            foreach (Type type in TempUtilities.GetAllChildrenOfClass<BagChange>()) {
                bagChanges.Add((BagChange)Activator.CreateInstance(type));
            }

            foreach (Type type in TempUtilities.GetAllChildrenOfClass<AdjacencyChange>()) {
                adjacencyChanges.Add((AdjacencyChange)Activator.CreateInstance(type));
            }
        }

        public override void Unload() {
            climates = null;
            evilClimates = null;
            eventChanges = null;
            itemChanges = null;
            setBonusChanges = null;
            buffChanges = null;
            lootChanges = null;
            bagChanges = null;
            adjacencyChanges = null;

            TerraTempInstance = null;
        }

        #endregion Loading Overrides

        #region Visual Overrides

        public override void ModifyLightingBrightness(ref float scale) {
            //Hypothermia/Heat Stroke "Blackout" Effect
            if (Main.LocalPlayer.HasBuff(ModContent.BuffType<Hypothermia>()) || Main.LocalPlayer.HasBuff(ModContent.BuffType<HeatStroke>())) {
                scale -= 0.34f;
            }
        }

        #endregion

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
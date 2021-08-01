using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Changes;
using TerraTemp.Custom;

namespace TerraTemp.Common.Systems {

    /// <summary>
    /// System that handles all of the content lists in the mod that have some effect on
    /// temperature, from climates to holding out items and all in-between.
    /// </summary>
    public class ContentListSystem : ModSystem {

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
        /// Hashset of all NPCs that are defined as "warm" that will determine whether or not these
        /// NPCs will increase a player's temperature slightly upon hitting them.
        /// </summary>
        public static HashSet<int> warmNPCTypes;

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

            /*foreach (Type type in TempUtilities.GetAllChildrenOfClass<Climate>()) {
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
            } */

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
        }

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
    }
}
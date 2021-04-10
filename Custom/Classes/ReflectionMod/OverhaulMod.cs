using System;
using System.Reflection;
using Terraria.ModLoader;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Patches;

namespace TerraTemp.Custom.Classes.ReflectionMod {

    //Last Update with Overhaul Version 4.5.2
    [InternalModName("TerrariaOverhaul")]
    public class OverhaulMod : ReflectionMod {
        public readonly PropertyInfo currentSeason;

        public OverhaulMod(Mod instance) : base(instance) {
            MethodInfo updateLifeRegenMethod;
            MethodInfo preUpdateMethod;
            foreach (Type type in ModTypes) {
                if (type.Name == "SeasonsAPI") {
                    currentSeason = type.GetProperty("CurrentSeason", BindingFlags.Public | BindingFlags.Static);
                    if (currentSeason == null) {
                        throw new Exception("Error Retrieving Overhaul Current Season Property Info! Report immediately!");
                    }
                }

                if (type.Name == "OverhaulPlayer") {
                    updateLifeRegenMethod = type.GetMethod("UpdateLifeRegen", BindingFlags.Public | BindingFlags.Instance);
                    preUpdateMethod = type.GetMethod("PreUpdate", BindingFlags.Public | BindingFlags.Instance);
                    if (updateLifeRegenMethod != null && preUpdateMethod != null) {
                        OverhaulILEdits.SubscribeToEvents(updateLifeRegenMethod, preUpdateMethod, type);
                    }
                    else {
                        throw new Exception("Erorr loading either Pre Update or Update Life Regen method for Terraria Overhaul! Report immediately!");
                    }
                }
            }
        }

        public enum SeasonID {
            Spring,
            Summer,
            Autumn,
            Winter
        }

        public bool IsSeasonOccuring(SeasonID season) {
            return (SeasonID)currentSeason.GetValue(null) == season;
        }
    }
}
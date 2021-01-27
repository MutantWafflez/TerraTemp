using System;
using System.Reflection;
using Terraria.ModLoader;
using TerraTemp.Custom.Attributes;

namespace TerraTemp.Custom.Classes.ReflectionMod {

    //Last Update with Overhaul Version 4.5.2
    [InternalModName("TerrariaOverhaul")]
    public class OverhaulMod : ReflectionMod {
        public readonly PropertyInfo currentSeason;

        public OverhaulMod(Mod instance) : base(instance) {
            foreach (Type type in ModTypes) {
                if (type.Name == "SeasonsAPI") {
                    currentSeason = type.GetProperty("CurrentSeason", BindingFlags.Public | BindingFlags.Static);
                    if (currentSeason == null) {
                        throw new Exception("Error Retrieving Overhaul Current Season Property Info! Report immediately!");
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
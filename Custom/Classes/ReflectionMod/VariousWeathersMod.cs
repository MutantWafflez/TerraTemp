using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria.ModLoader;
using TerraTemp.Custom.Attributes;

namespace TerraTemp.Custom.Classes.ReflectionMod {

    //Last updated with Various Weathers Version 1.1
    [InternalModName("Events")]
    public class VariousWeathersMod : ReflectionMod {
        public readonly FieldInfo ListOfActiveEvents;

        public VariousWeathersMod(Mod instance) : base(instance) {
            foreach (Type type in ModTypes) {
                if (type.Name == "MyWorld") {
                    ListOfActiveEvents = type.GetField("activeEvents", BindingFlags.Public | BindingFlags.Static);
                    if (ListOfActiveEvents == null) {
                        throw new Exception("Error Retrieving Various Weathers Active Events Field Info! Report immediately!");
                    }
                }
            }
        }

        public enum VariousWeatherEventID : int {
            Meteor = 0,
            Lightning = 1,
            Jellyfish = 2,
            AcidRain = 3,
            Ashfall = 4,
            HeavyRain = 5,
            Windy = 6,
            HeavyWinds = 7,
            Hail = 8,
            HeatWave = 9,
            LightRain = 10,
            AshStorm = 11,
            Aurora = 12,
            Hurricane = 13,
            Tremors = 14,
            Tranquil = 15,
            Butterflies = 16,
            Fireflies = 17,
            ColdFront = 18,
            Stardust = 19,
            CrystalRain = 20,
            VileRain = 21,
            CrimsonRain = 22,
            DryLightning = 23,
            BloodRain = 24,
            GravityFlux = 25,
            HealingRain = 26,
            AutumnWinds = 27,
            HoneyRain = 28,
            StrangeSeas = 29
        }

        /// <summary>
        /// Returns whether or not any given Various Weathers Event is taking place.
        /// </summary>
        /// <param name="eventID"> The ID of the event in question. </param>
        public bool IsEventOccuring(VariousWeatherEventID eventID) {
            List<int> currentlyActiveEvents = new List<int>();
            currentlyActiveEvents = (List<int>)ListOfActiveEvents.GetValue(currentlyActiveEvents);
            return currentlyActiveEvents.Contains((int)eventID);
        }
    }
}
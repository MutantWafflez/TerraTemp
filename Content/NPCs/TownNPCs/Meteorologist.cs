/*
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using TerraTemp.Common.Systems;
using TerraTemp.Content.Items.Accessories;
using TerraTemp.Content.Items.Miscellaneous;
using TerraTemp.Content.Items.Potions;
using TerraTemp.Content.Items.Tiles.Furniture;
using TerraTemp.Content.Items.Tomes;
using TerraTemp.Custom.Structs;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.NPCs.TownNPCs {
    [AutoloadHead]
    public class Meteorologist : ModNPC {
        public static readonly ShopItem[] shopItems = {
            new ShopItem(ItemID.WeatherRadio),
            new ShopItem(ModContent.ItemType<Thermometer>()),
            new ShopItem(ModContent.ItemType<EnchantedBookshelf>()),
            new ShopItem(ModContent.ItemType<FlameTome>()),
            new ShopItem(ModContent.ItemType<FrostTome>()),
            new ShopItem(ItemID.WarmthPotion, () => NPC.downedBoss3),
            new ShopItem(ModContent.ItemType<CoolingPotion>(), () => NPC.downedBoss3),
            new ShopItem(ModContent.ItemType<SatanicCross>(), () => Main.bloodMoon)
        };

        public override void SetupShop(Chest shop, ref int nextSlot) {
            foreach (ShopItem shopItem in shopItems) {
                if (shopItem.IsForSale()) {
                    shop.item[nextSlot].SetDefaults(shopItem.shopItemID);
                    nextSlot++;
                }
            }
        }

        #region Defaults Related

        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 21;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
                Velocity = 1f
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }

        public override void SetDefaults() {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 50;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain,

                new FlavorTextBestiaryInfoElement("Mods.TerraTemp.BestiaryInfo.Meteorologist")
            });
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) => NPC.downedSlimeKing && Main.raining || NPC.downedBoss2;

        public override List<string> SetNPCNameList() => new List<string> {
            "Aimé",
            "Diodore",
            "Nathanaël",
            "Arnaud",
            "Guillaume",
            "Justin",
            "Loan",
            "Gilbert",
            "Loup",
            "Florian",
            "Bernard",
            "Philippe",
            "Dany",
            "Corin",
            "Rosaire",
            "Bertrand",
            "Mathieu"
        };

        #endregion

        #region Chat Related

        public override void SetChatButtons(ref string button, ref string button2) {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = LocalizationUtilities.GetTerraTempTextValue("NPCButton2." + GetType().Name);
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
            if (firstButton) {
                shop = true;
            }
            else {
                UISystem uiSystem = ModContent.GetInstance<UISystem>();

                //Open forecast UI
                Main.npcChatText = "";
                uiSystem.forecastInterface.SetState(uiSystem.forecastUI);
            }
        }

        public override string GetChat() {
            WeightedRandom<string> listOfPossibleChats = new WeightedRandom<string>();

            //Chats that can appear whenever
            listOfPossibleChats.Add(
                "You know, I've always wondered, how exactly are we even alive right now? Considering how close we are to space, there doesn't seem to be much of an ozone layer to protect us from the sun's radiation. Oh well.");
            listOfPossibleChats.Add("I don't know how the things that live in the Underworld even stand it. That heat is unbearable!");
            listOfPossibleChats.Add("The climate of the Crimson is fascinating. It seems like the blood that covers the place evaporates as a part of the water cycle, causing it to be more humid than usual. Very peculiar.");
            listOfPossibleChats.Add("That rainbow that perpetually sits in the Hallow has always confused me. Usually rainbows only appear after it rains, yet the rainbow stays long after the rain has ceased. It makes no sense!");
            listOfPossibleChats.Add("On the surface level, those ice torches found in the Tundra make sense to be cold. But scientifically speaking, it makes absolutely no sense. How in the hell can fire be cold?");
            listOfPossibleChats.Add(
                "The climates of Terraria are either really fascinating or really boring. There's fascinating phenomenon like the blood-water cycle of the Crimson, then there's Desert which is just painfully hot. Boring!");
            listOfPossibleChats.Add("Alright, I have to ask. How do you survive in Space, let alone stay up there for long periods of time? Heat is about as scarce as a of Rod of Discord up there!");
            listOfPossibleChats.Add(
                "Have you traveled through the Corruption? It's climate is something of which I've never felt before. It's cold, but even more than that, it's like being in the place inspires your body to WANT to be cold! I'm fascinated, but I'm never stepping foot near there again!");
            listOfPossibleChats.Add(
                "I've always wondered, why doesn't the center of this world not have a climate similar to that of the Jungle? Surely being in the center would imply its near the equator, thus likely having a tropical climate...");
            listOfPossibleChats.Add("I'd love to live in the Crimson to study its climate more. Unlike the Corruption, it's much more warm and humid, but I don't think I'd survive with all the dubious monsters that creep around there.");

            //Chats that appear during events
            //Rain
            listOfPossibleChats.ConditionallyAdd("The rain. Such a beautiful event. I've seen it thousands upon thousands of times, yet it never ceases to amaze me.", Main.raining, 2);
            listOfPossibleChats.ConditionallyAdd("You want to hear the process by which water forms into clouds and then precipitates to fall toward the ground? ...I'll take the silence as a no.", Main.raining, 2);
            listOfPossibleChats.ConditionallyAdd("I'd be worried to travel anywhere particularly hot right now. Humidity is particularly high!", Main.raining, 2);
            listOfPossibleChats.ConditionallyAdd("Do you like the rain? I do. No bias from me though, of course.", Main.raining, 2);
            //Blood moon
            listOfPossibleChats.ConditionallyAdd(
                "You know, usually, Lunar Eclipses like these don't really have any effect on a given climate. However, judging by the several monsters outside, I'd bet a bit more on the air being a bit stickier than usual.",
                Main.bloodMoon, 2);
            listOfPossibleChats.ConditionallyAdd("Although it's not within my scope of practice, blood moons intrigue me quite a lot due to the fact that in these parts they seem to have a profound effect on the surface climate.",
                Main.bloodMoon, 2);
            listOfPossibleChats.ConditionallyAdd("Hello, can you do me a favor and not let any monsters in here? I'd rather like to study the blood moon without losing my limbs. Merci.", Main.bloodMoon, 2);
            listOfPossibleChats.ConditionallyAdd("Je n’aime pas les cris incessants du monstre!", Main.bloodMoon, 2);
            //Solar eclipse
            listOfPossibleChats.ConditionallyAdd("I wouldn't count on the sun's heat today. The moon seems to have a profound effect on blocking both the light and heat of the sun.", Main.eclipse, 2);
            listOfPossibleChats.ConditionallyAdd("Les cris du monstre sont très extrêmes aujourd’hui...", Main.eclipse, 2);
            listOfPossibleChats.ConditionallyAdd("I forecast many corpses within the coming hours, whether they be your or the monsters'.", Main.eclipse, 2);
            listOfPossibleChats.ConditionallyAdd("You happen to have any white paper anywhere? I may need it in case you die.", Main.eclipse, 2);
            //High wind
            bool isHighWind = Math.Abs(Main.windPhysicsStrength * 100f) >= 30f;
            listOfPossibleChats.ConditionallyAdd("When I was younger, I was always curious as why wind was caused by the sun. It's one of the many questions I had that led me to my current profession.", isHighWind, 2);
            listOfPossibleChats.ConditionallyAdd("I wouldn't suggest going anywhere near the Tundra right now. That place is a real killer with high winds like this if you're not ready!", isHighWind, 2);
            //Pumpkin Moon
            listOfPossibleChats.ConditionallyAdd("Is there something that is projecting that image upon the moon? How is that even possible?", Main.pumpkinMoon, 2);
            listOfPossibleChats.ConditionallyAdd("I can feel the heat and any confidence I may or may not of had seeping out of my body. Qu'est-ce que vous faites!?", Main.pumpkinMoon, 2);
            //Frost Moon
            listOfPossibleChats.ConditionallyAdd("Please don't tell me you're on the naughty list.", Main.snowMoon, 2);
            listOfPossibleChats.ConditionallyAdd("I have a strong premonition that this very sudden cold is your doing, is that correct?", Main.snowMoon, 2);

            return listOfPossibleChats;
        }

        #endregion
    }
}*/


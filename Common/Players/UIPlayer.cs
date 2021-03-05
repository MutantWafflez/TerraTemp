using IL.Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;
using TerraTemp.Content.UI;

namespace TerraTemp.Common.Players {

    /// <summary>
    /// ModPlayer that handles UI, such as saving the offset of draggable UI.
    /// </summary>
    public class UIPlayer : ModPlayer {
        public ThermometerState ThermometerState => TerraTemp.Instance.thermometerUI;

        public UserInterface ForecastInterface => TerraTemp.Instance.forecastInterface;

        public override TagCompound Save() {
            return new TagCompound {
                {"thermometerUIOffset", ThermometerState.draggableElement.offset}
            };
        }

        public override void Load(TagCompound tag) {
            if (ThermometerState != null && ThermometerState != null) {
                ThermometerState.draggableElement.offset = tag.Get<Vector2>("thermometerUIOffset");
            }
        }

        public override void PostUpdate() {
            //Hide forecast UI upon stop talking to NPC
            if (player.talkNPC == -1 && ForecastInterface.CurrentState != null) {
                ForecastInterface.SetState(null);
            }
        }
    }
}
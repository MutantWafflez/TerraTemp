using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TerraTemp.Common.Players {

    /// <summary>
    /// ModPlayer that handles UI, such as saving the offset of draggable UI.
    /// </summary>
    public class UIPlayer : ModPlayer {

        #region UI I/O

        public override TagCompound Save() {
            return new TagCompound {
                {"thermometerUIOffset", TerraTemp.TerraTempInstance.thermometerUI.draggableElement.offset}
            };
        }

        public override void Load(TagCompound tag) {
            if (TerraTemp.TerraTempInstance.thermometerUI != null && TerraTemp.TerraTempInstance.thermometerInterface != null) {
                TerraTemp.TerraTempInstance.thermometerUI.draggableElement.offset = tag.Get<Vector2>("thermometerUIOffset");
            }
        }

        #endregion
    }
}
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraTemp.Common.Systems;

namespace TerraTemp.Common.Players {

    /// <summary>
    /// ModPlayer that handles UI, such as saving the offset of draggable UI.
    /// </summary>
    public class UIPlayer : ModPlayer {

        #region UI I/O

        public override TagCompound Save() {
            return new TagCompound {
                {"thermometerUIOffset", UIHandlerSystem.UIHandlerSystemInstance.thermometerUI.draggableElement.offset}
            };
        }

        public override void Load(TagCompound tag) {
            if (UIHandlerSystem.UIHandlerSystemInstance.thermometerUI != null && UIHandlerSystem.UIHandlerSystemInstance.thermometerInterface != null) {
                UIHandlerSystem.UIHandlerSystemInstance.thermometerUI.draggableElement.offset = tag.Get<Vector2>("thermometerUIOffset");
            }
        }

        #endregion
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;

namespace TerraTemp.Content.UI {

    /// <summary>
    /// UIImage class that can be colored.
    /// </summary>
    public class ColorableUIImage : UIImage {
        public Color textureColor;

        public Texture2D imageTexture;

        public ColorableUIImage(Texture2D texture) : base(texture) {
            imageTexture = texture;
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(imageTexture, GetDimensions().ToRectangle(), textureColor);
        }
    }
}
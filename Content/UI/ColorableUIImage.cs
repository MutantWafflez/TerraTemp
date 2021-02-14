using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

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
            Rectangle dimensions = GetDimensions().ToRectangle();
            dimensions.Width = (int)(dimensions.Width * ImageScale);
            dimensions.Height = (int)(dimensions.Height * ImageScale);
            spriteBatch.Draw(imageTexture, dimensions, textureColor);
        }
    }
}
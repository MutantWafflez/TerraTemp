using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.UI;

namespace TerraTemp.Content.UI {

    /// <summary>
    /// UIElement that can be dragged, specific to the Thermometer UI. This is adapted code from the
    /// DraggableUIPanel in ExampleMod. Thanks tML team!
    /// </summary>
    public class ThermometerDraggableElement : UIElement {
        public bool dragging;

        // Stores the offset from the top left of the UIPanel while dragging.
        public Vector2 offset;

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            MouseState currentMouseState = Mouse.GetState();

            if (ContainsPoint(Main.MouseScreen)) {
                Main.LocalPlayer.mouseInterface = true;
            }

            //Checks for intersection of UI and the mouse and allows for dragging as long as CTRL is being pressed.
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) && ContainsPoint(Main.MouseScreen)) {
                if (currentMouseState.LeftButton == ButtonState.Pressed) {
                    DragStart();
                }
            }
            if (currentMouseState.LeftButton == ButtonState.Released && dragging) {
                DragEnd();
            }

            if (dragging) {
                Left.Set(Main.mouseX - offset.X, 0f);
                Top.Set(Main.mouseY - offset.Y, 0f);
                Recalculate();
            }

            var parentSpace = Parent.GetDimensions().ToRectangle();
            if (!GetDimensions().ToRectangle().Intersects(parentSpace)) {
                Left.Pixels = Utils.Clamp(Left.Pixels, 0, parentSpace.Right - Width.Pixels);
                Top.Pixels = Utils.Clamp(Top.Pixels, 0, parentSpace.Bottom - Height.Pixels);
                // Recalculate forces the UI system to do the positioning math again.
                Recalculate();
            }
        }

        private void DragStart() {
            offset = new Vector2(Main.mouseX - Left.Pixels, Main.mouseY - Top.Pixels);
            dragging = true;
        }

        private void DragEnd() {
            Vector2 end = Main.MouseScreen;
            dragging = false;

            Left.Set(end.X - offset.X, 0f);
            Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }
    }
}
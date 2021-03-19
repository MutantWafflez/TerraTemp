using Microsoft.Xna.Framework;

namespace TerraTemp.Custom.Structs {

    /// <summary>
    /// Simple string "extension" struct that holds a Color value. Primarily used for tooltip color saving.
    /// </summary>
    public struct ColoredString {
        public string value;
        public Color stringColor;

        public ColoredString(string stringValue, Color colorOfString = default) {
            value = stringValue;
            stringColor = colorOfString;
        }
    }
}
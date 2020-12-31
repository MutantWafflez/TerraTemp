using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.Climates {

    public class LihzahrdClimate : Climate {
        public override float TemperatureModification => 10f;

        public override float HumidityModification => 0.5f;

        //Since vanilla doesn't have a bool for when the player is in the Lihzhard "Zone", we will do the check that vanilla does for it
        public override bool PlayerZoneBool(Player player) => Framing.GetTileSafely((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16).wall == WallID.LihzahrdBrickUnsafe;
    }
}
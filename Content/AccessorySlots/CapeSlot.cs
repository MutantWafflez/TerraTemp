namespace TerraTemp.Content.AccessorySlots {
    public class CapeSlot : ModAccessorySlot {
        public override bool DrawVanitySlot => false;

        public override bool DrawDyeSlot => false;

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) => true;
    }
}
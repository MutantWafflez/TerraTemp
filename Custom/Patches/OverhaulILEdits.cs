using System;
using System.Reflection;
using MonoMod.Cil;
using MonoMod.RuntimeDetour.HookGen;

namespace TerraTemp.Custom.Patches {

    /// <summary>
    /// Class that handles IL Edits on the Terraria Overhaul mod.
    /// </summary>
    public static class OverhaulILEdits {
        private static MethodInfo updateLifeRegenMethod;

        private static event ILContext.Manipulator ModifyLifeRegen {
            add => HookEndpointManager.Modify(updateLifeRegenMethod, value);
            remove => HookEndpointManager.Unmodify(updateLifeRegenMethod, value);
        }

        public static void SubscribeToEvents(MethodInfo lifeRegenMethod) {
            updateLifeRegenMethod = lifeRegenMethod;
            ModILManager.LoadEvent += LoadOverhaulEdits;
            ModILManager.UnloadEvent += UnloadOverhaulEdits;
        }

        private static void LoadOverhaulEdits() {
            ModifyLifeRegen += OverhaulILEdits_ModifyLifeRegen;
        }

        private static void UnloadOverhaulEdits() {
            ModifyLifeRegen -= OverhaulILEdits_ModifyLifeRegen;
        }

        private static void OverhaulILEdits_ModifyLifeRegen(ILContext il) {
            ILCursor c = new ILCursor(il);

            if (c.TryGotoNext(i => i.MatchLdcI4(4))) {
                c.Index++;

                c.Emit(Mono.Cecil.Cil.OpCodes.Pop);
                c.Emit(Mono.Cecil.Cil.OpCodes.Ldc_I4_0);
            }
        }
    }
}
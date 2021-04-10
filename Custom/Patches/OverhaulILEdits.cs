using System;
using System.Reflection;
using Terraria;
using MonoMod.Cil;
using MonoMod.RuntimeDetour.HookGen;
using Terraria.ModLoader;

namespace TerraTemp.Custom.Patches {

    /// <summary>
    /// Class that handles IL Edits on the Terraria Overhaul mod.
    /// </summary>
    public static class OverhaulILEdits {
        private static MethodInfo updateLifeRegenMethod;
        private static MethodInfo preUpdateMethod;
        private static Type overhaulPlayerType;

        private static event ILContext.Manipulator ModifyLifeRegen {
            add => HookEndpointManager.Modify(updateLifeRegenMethod, value);
            remove => HookEndpointManager.Unmodify(updateLifeRegenMethod, value);
        }

        private static event ILContext.Manipulator ModifyPreUpdate {
            add => HookEndpointManager.Modify(preUpdateMethod, value);
            remove => HookEndpointManager.Unmodify(preUpdateMethod, value);
        }

        public static void SubscribeToEvents(MethodInfo lifeRegenMethodInfo, MethodInfo preUpdateMethodInfo, Type overhaulPlayer) {
            updateLifeRegenMethod = lifeRegenMethodInfo;
            preUpdateMethod = preUpdateMethodInfo;
            overhaulPlayerType = overhaulPlayer;
            ModILManager.LoadEvent += LoadOverhaulEdits;
            ModILManager.UnloadEvent += UnloadOverhaulEdits;
        }

        private static void LoadOverhaulEdits() {
            ModifyLifeRegen += OverhaulILEdits_ModifyLifeRegen;
            ModifyPreUpdate += OverhaulILEdits_ModifyPreUpdate;
        }

        private static void UnloadOverhaulEdits() {
            ModifyLifeRegen -= OverhaulILEdits_ModifyLifeRegen;
            ModifyPreUpdate -= OverhaulILEdits_ModifyPreUpdate;
        }

        private static void OverhaulILEdits_ModifyLifeRegen(ILContext il) {
            ILCursor c = new ILCursor(il);

            if (c.TryGotoNext(i => i.MatchLdcI4(4))) {
                c.Index++;

                c.Emit(Mono.Cecil.Cil.OpCodes.Pop);
                c.Emit(Mono.Cecil.Cil.OpCodes.Ldc_I4_0);
            }
        }

        private static void OverhaulILEdits_ModifyPreUpdate(ILContext il) {
            ILCursor c = new ILCursor(il);

            if (c.TryGotoNext(i => i.MatchStloc(5))) {
                c.Index++;

                c.Emit(Mono.Cecil.Cil.OpCodes.Ldarg_0);
                c.Emit(Mono.Cecil.Cil.OpCodes.Ldc_I4_0);

                c.Emit(Mono.Cecil.Cil.OpCodes.Stfld, overhaulPlayerType.GetField("temperature", BindingFlags.Public | BindingFlags.Instance));
            }
        }
    }
}
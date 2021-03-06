﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NitroxPatcher.Patches;
using Harmony;
using System.Reflection;
using NitroxTest.Patcher.Test;
using System.Linq;

namespace NitroxTest.Patcher.Patches
{
    [TestClass]
    public class Equipment_RemoveItem_PatchTest
    {
        [TestMethod]
        public void Sanity()
        {
            List<CodeInstruction> instructions = PatchTestHelper.GenerateDummyInstructions(100);
            instructions.Add(new CodeInstruction(Equipment_RemoveItem_Patch.INJECTION_OPCODE, null));

            IEnumerable<CodeInstruction> result = Equipment_RemoveItem_Patch.Transpiler(null, instructions);
            Assert.AreEqual(109, result.Count());
        }

        [TestMethod]
        public void InjectionSanity()
        {
            List<CodeInstruction> beforeInstructions = PatchTestHelper.GetInstructionsFromMethod(Equipment_RemoveItem_Patch.TARGET_METHOD);

            IEnumerable<CodeInstruction> result = ClipMapManager_ShowEntities_Patch.Transpiler(Equipment_RemoveItem_Patch.TARGET_METHOD, beforeInstructions);

            Assert.IsTrue(beforeInstructions.Count < result.Count());
        }
    }
}

using DubsBadHygiene;
using HarmonyLib;
using Neandertalica_DBH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.Noise;

namespace Neandertalica_DBH
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            Log.Warning("Neandertalica_DBH: Harmony patching");
            var harmony = new Harmony("Geel.NeandertallicaDBS");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(Building_AssignableFixture), "Tick")]
    public static class Building_AssignableFixture_Tick
    {
        public static void Postfix(Building_AssignableFixture __instance)
        {
            if (__instance is WaterPit instance)
            {
                instance.PostTick();
            }
        }
    }

    [HarmonyPatch(typeof(Building_AssignableFixture), "SpawnSetup")]
    public static class Building_AssignableFixture_SpawnSetup
    {
        public static void Postfix(Building_AssignableFixture __instance, Map map, bool respawningAfterLoad)
        {
            if (__instance is WaterPit instrance)
            {
                instrance.PostSpawnSetup(map, respawningAfterLoad);
            }
        }
    }
}
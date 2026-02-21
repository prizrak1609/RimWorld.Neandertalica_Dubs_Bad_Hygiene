using DubsBadHygiene;
using HarmonyLib;
using RimWorld;
using RimWorld.BaseGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Verse;
using static HarmonyLib.Code;

namespace Neandertalica_DBH
{
    public class WaterPit: Building_AssignableFixture
    {
        public override FixtureType fixture => FixtureType.Basin;
        public override bool DrawBrokenPipe => false;

        private WaterPitThingComp waterPit;
        private CompWaterStorage storage;

        public WaterPit()
        {
        }

        public void PostTick()
        {
            Pawn pawn = this.InteractionCell.GetFirstPawn(this.Map);
            if (pawn != null && !pawn.Downed && !pawn.Dead && pawn.CurJob != null && pawn.CurJob.targetA.Thing == this)
            {
                storage.WaterStorage -= waterPit.Props.WaterPerUse;
            }
        }

        public void PostSpawnSetup(Map map, bool respawningAfterLoad)
        {
            if (waterPit == null)
            {
                waterPit = GetComp<WaterPitThingComp>();
            }

            if (storage == null)
            {
                storage = GetComp<CompWaterStorage>();
                storage.Props.WaterStorageCap = waterPit.Props.Capacity;
                storage.DrainTank = false;
                storage.WaterStorage = waterPit.Props.Capacity;
            }
        }

        public override AcceptanceReport Working(float WaterUsed = 0)
        {
            return storage.WaterStorage > 0 || base.Working(WaterUsed);
        }
    }
}

using DubsBadHygiene;
using HarmonyLib;
using RimWorld;
using RimWorld.BaseGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using static HarmonyLib.Code;

namespace Neandertalica_DBH
{
    public class WaterPit: Building_AssignableFixture, IWaterPitBase
    {
        public override FixtureType fixture => FixtureType.Basin;
        public override bool DrawBrokenPipe => false;

        private int postTickErrorKey = 0;
        private int workingErrorKey = 0;

        internal WaterStorage storage;

        public WaterPit()
        {
        }

        public virtual void PostTick()
        {
            if (base.ParentHolder is MinifiedThing)
            {
                return;
            }

            Pawn pawn = this.InteractionCell.GetFirstPawn(this.Map);
            if (pawn != null && !pawn.Downed && !pawn.Dead && pawn.CurJob != null && pawn.CurJob.targetA.Thing == this)
            {
                if (storage != null)
                {
                    storage.WaterStorage -= SettingsUI.Settings.WaterPerUse;
                } else
                {
                    Log.ErrorOnce(LogUtils.CreateLogMessage("WaterPit has no CompWaterStorage"), postTickErrorKey);
                }
            }
        }

        public virtual void PostSpawnSetup(Map map, bool respawningAfterLoad)
        {
            if (storage == null)
            {
                storage = GetComp<WaterStorage>();
                storage.Props.WaterStorageCap = SettingsUI.Settings.Capacity;
                storage.DrainTank = false;
                storage.WaterStorage = SettingsUI.Settings.Capacity;
            }
        }

        public override AcceptanceReport Working(float WaterUsed = 0)
        {
            bool hasWater = false;
            if (storage != null)
            {
                hasWater = storage.WaterStorage > 0;
            } else
            {
                Log.ErrorOnce(LogUtils.CreateLogMessage("WaterPit has no CompWaterStorage."), workingErrorKey);
            }
            return hasWater || base.Working(WaterUsed);
        }
    }
}

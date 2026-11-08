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
    public class WaterPitFree: WaterPit
    {
        private float contaminationLevel = 0;
        private const int ticksPerSecond = 60;

        public override ContaminationLevel ContaminationLevel
        {
            get
            {
                if (contaminationLevel >= 100)
                {
                    return ContaminationLevel.Contaminated;
                }

                return ContaminationLevel.Untreated;
            }
        }

        public WaterPitFree()
        {
        }

        public override void PostTick()
        {
            if (base.ParentHolder is MinifiedThing)
            {
                return;
            }

            base.PostTick();

            if (!this.IsHashIntervalTick(1 * ticksPerSecond))
            {
                return;
            }

            if (storage.IsDraining())
            {
                contaminationLevel = 0;
                return;
            }

            if (contaminationLevel < 100)
            {
                contaminationLevel += waterPit.Props.ContaminationPercentPerSecond;
            }
        }

        public override void PostSpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.PostSpawnSetup(map, respawningAfterLoad);

            if (storage != null)
            {
                storage.DidWaterDrain += didWaterDrain;
            }
        }

        private void didWaterDrain()
        {
            contaminationLevel = 0;
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref contaminationLevel, "WaterPitFreeContaminationLevel", defaultValue: 0);
        }

        public override string GetInspectString()
        {
            if (base.ParentHolder is MinifiedThing)
            {
                return base.GetInspectString();
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.GetInspectString());
            if (stringBuilder.Length != 0)
            {
                stringBuilder.AppendLine();
            }

            stringBuilder.Append($"Contamination Level: {contaminationLevel}%");

            return stringBuilder.ToString().TrimEndNewlines();
        }
    }
}

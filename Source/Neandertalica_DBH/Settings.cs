using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Neandertalica_DBH
{
    public class Settings : ModSettings
    {
        public float WaterPerUse = 0.01f;
        public float ContaminationPercentPerSecond = 0.12f;
        public int Capacity = 500;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref WaterPerUse, "WaterPitWaterPerUse", 0.01f);
            Scribe_Values.Look(ref ContaminationPercentPerSecond, "WaterPitContaminationPercentPerSecond", 0.12f);
            Scribe_Values.Look(ref ContaminationPercentPerSecond, "WaterPitCapacity", 500);
        }

        public void Reset()
        {
            WaterPerUse = 0.01f;
            ContaminationPercentPerSecond = 0.12f;
            Capacity = 500;
        }
    }
}

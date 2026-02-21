using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Neandertalica_DBH
{
    public class CompProperties_WaterPit: DubsBadHygiene.CompProperties_WaterInlet
    {
        public float WaterPerUse = 0.01f;
        public CompProperties_WaterPit()
        {
            compClass = typeof(WaterPitThingComp);
        }
    }
}

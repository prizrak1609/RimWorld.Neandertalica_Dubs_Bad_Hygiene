using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Neandertalica_DBH
{
    [DefOf]
    public class Defs
    {
        public static ThingDef N_WaterPit;
        public static ThingDef N_FreeWaterPit;

        public static ThingDef[] AllDefs => new ThingDef[2] { N_WaterPit, N_FreeWaterPit };
    }
}

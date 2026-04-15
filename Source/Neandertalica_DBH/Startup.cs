using DubsBadHygiene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Neandertalica_DBH
{
    [StaticConstructorOnStartup]
    public class Startup
    {
        static Startup()
        {
            Log.Message("Dubs Bad Hygiene Water Pit: Checking active mods.");
            
            DefExtensions.FixtureDefs.Add(Defs.N_WaterPit);
        }
    }
}

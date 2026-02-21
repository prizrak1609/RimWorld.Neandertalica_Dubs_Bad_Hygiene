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
            Log.Message("Neandertalica_DBH: Checking active mods.");
            if (ModLister.GetModWithIdentifier("dubwise.dubsbadhygiene").Active == false)
            {
                throw new Exception("Neandertalica + Dubs Bad Hygiene: 'Dubs Bad Hygiene' is not active.");
            }
            if (ModLister.GetModWithIdentifier("titaniusrex.neandertallica").Active == false)
            {
                throw new Exception("Neandertalica + Dubs Bad Hygiene: 'Neandertallica' is not active.");
            }

            DefExtensions.FixtureDefs.Add(Defs.N_WaterPit);
        }
    }
}

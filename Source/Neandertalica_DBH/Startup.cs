using DubsBadHygiene;
using RimWorld;
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
            Log.Message(LogUtils.CreateLogMessage("Starting"));
            DefExtensions.FixtureDefs.Add(Defs.N_WaterPit);

            if (VersionControl.CurrentMajor <= 1 && VersionControl.CurrentMinor < 7)
            {
                Log.Error(LogUtils.CreateLogMessage("Water Pit that costs nothing will not be available in RimWorld version below 1.7"));
            }

            Log.Message(LogUtils.CreateLogMessage("Started successfully"));
        }
    }
}

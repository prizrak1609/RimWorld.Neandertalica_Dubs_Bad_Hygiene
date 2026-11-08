using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Neandertalica_DBH
{
    public interface IWaterPitBase
    {
        void PostTick();
        void PostSpawnSetup(Map map, bool respawningAfterLoad);
    }
}

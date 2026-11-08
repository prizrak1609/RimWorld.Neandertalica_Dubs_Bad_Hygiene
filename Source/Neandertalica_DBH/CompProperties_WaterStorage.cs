using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neandertalica_DBH
{
    public class CompProperties_WaterStorage: DubsBadHygiene.CompProperties_WaterStorage
    {
        public CompProperties_WaterStorage()
        {
            compClass = typeof(WaterStorage);
        }
    }
}

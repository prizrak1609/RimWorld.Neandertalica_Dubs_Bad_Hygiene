using DubsBadHygiene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neandertalica_DBH
{
    public class WaterStorage: CompWaterStorage
    {
        public Action DidWaterDrain;
        public void postDrain()
        {
            DidWaterDrain?.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Scheduling.MetaHeuristic
{
    public class Gene
    {
        public int AvalebleTimeIndex;
        public int ClassIndex;
        public Gene(int AvalebleTimeIndex, int ClassIndex)
        {
            this.AvalebleTimeIndex = AvalebleTimeIndex;
            this.ClassIndex = ClassIndex;
        }
        public Gene()
        {

        }
    }
}

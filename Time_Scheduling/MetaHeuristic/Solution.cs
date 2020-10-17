using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Scheduling.MetaHeuristic
{
    public class Solution
    {
        public int Cost;
        public int[] Master;
        public Gene[] Genes;
        public Solution(int MasterSize,int GenesSize)
        {
            Master = new int[MasterSize];
            Genes = new Gene[GenesSize];
        }
        public Solution()
        {

        }
        public void SetCost()
        {

        }
    }
}

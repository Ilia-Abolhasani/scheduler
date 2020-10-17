using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Scheduling.MetaHeuristic
{
    public class Algorithm_Genetic
    {
        public int Iteration;
        public int Npop;
        public int  NCrossover;
        public int NMutation;        
        public List<Solution> Population;        
        public Algorithm_Genetic(int Iteration,int Npop,float PCrossover,float PMutation)
        {
            this.Iteration = Iteration;
            this.Npop = Npop;
            NCrossover = (int)(Npop * PCrossover);
            NMutation = (int)(Npop * PMutation);            
        }
        public Solution Start()
        {
            Initialization_population();            
            for (int i = 0; i < Npop; i++)
            {
                for (int j = 0; j < NMutation; j++)                
                    Population.Add(Mutation(Select()));                
                for (int j = 0; j < NCrossover; j++)
                {
                    Solution[] TempSolution = Crossover(Select(), Select());
                    Population.Add(TempSolution[0]);
                    Population.Add(TempSolution[1]);
                }
                Population.OrderBy(s => s.Cost);//sort population
                Control_population();
            }
            return Population[0];
        }
        public void Initialization_population()
        {
            for (int i = 0; i < Npop; i++)
            {
                Solution solution = new Solution();
                solution.SetCost();
                Population.Add(solution);
            }
        }
        public Solution Mutation(Solution Input)
        {
            return new Solution(10, 10);
        }
        public Solution[] Crossover(Solution Input1, Solution Input2)
        {
            return new Solution[2];
        }
        public Solution Select()
        {
            return Population[new Random().Next(0, Npop)];            
        }
        public void Control_population()
        {
            int ExterIndex = Population.Count - Npop;
            for (int i = 0; i < ExterIndex; i++)				 
                Population.RemoveAt(Npop);
        }       
    }
}

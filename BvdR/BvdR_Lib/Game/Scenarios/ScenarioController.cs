using BvdR_Lib.Game.Acts;
using BvdR_Lib.Game.Acts.BagEnd;
using BvdR_Lib.Game.Scenarios.Moria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Scenarios
{
    public class ScenarioController
    {
        public LinkedList<Scenario> AllActs = new LinkedList<Scenario>();
        public LinkedList<Scenario>.Enumerator CurrentAct;
        
        public ScenarioController()
        {
            AllActs.AddLast(new BagEndAct());
            AllActs.AddLast(new MoriaScenario());
            AllActs.AddLast(new MoriaScenario());
            CurrentAct = AllActs.GetEnumerator();
        }

        public void MovePath(Scenario.PathType path) 
        {
            
        }

        public ScenarioPath[] GetCurrentPaths()
        {
            if (!(CurrentAct.Current is Scenario))
                return [];
            Scenario currentScenario = (Scenario)CurrentAct.Current;
            
        }

        public void NextAct()
        {
            //todo
        }

    }
}

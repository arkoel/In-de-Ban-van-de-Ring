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
    public class ActController
    {
        public LinkedList<Act> AllActs = new LinkedList<Act>();
        public LinkedList<Act>.Enumerator CurrentAct;
        
        public ActController()
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

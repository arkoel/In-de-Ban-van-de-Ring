using BvdR_Lib.Game.Acts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Scenarios
{
    public abstract class Scenario
    {
        //public List<>
        [Length(6,6)]
        private LinkedList<IScenarioEvent> _scenarioEvents;
        public LinkedList<IScenarioEvent>.Enumerator CurrentEvent;
        public Dictionary<PathType, ScenarioPath> ScenarioPaths { get; set; }

        public Scenario(LinkedList<IScenarioEvent> scenarioEvents, Dictionary<PathType,ScenarioPath> paths) 
        {
            _scenarioEvents = scenarioEvents;
            CurrentEvent = _scenarioEvents.GetEnumerator();
            ScenarioPaths = paths;
        }


        public enum PathType
        {
            Friendship,
            Traveling,
            Hiding,
            Fighting,
        }

    }
}

using BvdR_Lib.Game.Acts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Scenarios
{
    public abstract class Scenario : Act
    {
        [Length(6,6)]
        private LinkedList<ScenarioEvent> _scenarioEvents;
        public LinkedList<ScenarioEvent>.Enumerator CurrentEvent;
        public Dictionary<PathType, ScenarioPath> ScenarioPaths { get; set; }

        public Scenario(LinkedList<ScenarioEvent> scenarioEvents, Dictionary<PathType,ScenarioPath> paths) 
        {
            _scenarioEvents = scenarioEvents;
            CurrentEvent = _scenarioEvents.GetEnumerator();
            ScenarioPaths = paths;
        }



        public override void Start()
        {
            //?
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

using BvdR_Lib.Game.Acts;
using BvdR_Lib.Game.Prologs;
using System.ComponentModel.DataAnnotations;

namespace BvdR_Lib.Game.Scenarios
{
    public abstract class Scenario
    {
        public List<IPrologue> Prologues { get; set; }
        [Length(6, 6)]
        private LinkedList<IScenarioEvent> _scenarioEvents;
        public LinkedList<IScenarioEvent>.Enumerator CurrentEvent;
        public Dictionary<PathType, ScenarioPath> ScenarioPaths { get; set; }

        public Scenario(List<IPrologue> prologues, LinkedList<IScenarioEvent> scenarioEvents, Dictionary<PathType, ScenarioPath> paths)
        {
            Prologues = prologues;
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
            AnyPath
        }

    }
}

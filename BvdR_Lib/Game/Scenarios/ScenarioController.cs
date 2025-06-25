using BvdR_Lib.Game.Scenarios.Moria;

namespace BvdR_Lib.Game.Scenarios
{
    public class ScenarioController
    {
        public LinkedList<Scenario> AllActs = new LinkedList<Scenario>();
        public LinkedList<Scenario>.Enumerator CurrentAct;

        public ScenarioController()
        {
            AllActs.AddLast(new MoriaScenario());
            AllActs.AddLast(new MoriaScenario());
            CurrentAct = AllActs.GetEnumerator();
        }

        public void MovePath(Scenario.PathType path)
        {

        }

        public Scenario.PathType[] GetCurrentPaths() =>
            CurrentAct.Current.ScenarioPaths.Keys.ToArray();


        public void NextAct()
        {
            //todo
        }

    }
}

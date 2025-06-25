using BvdR_Lib.Game.Acts;
using BvdR_Lib.Game.Prologs;
using BvdR_Lib.Game.Prologs.BagEnd;

namespace BvdR_Lib.Game.Scenarios.Moria
{
    public class MoriaScenario : Scenario
    {
        public MoriaScenario() : base(
            new List<IPrologue>()
            {
                new BagEnd(),
                //new Rivendell(),
                //TODO
            },
            new LinkedList<IScenarioEvent>() /*TODO create Events*/,
            new Dictionary<PathType, ScenarioPath>
            {
                { PathType.Fighting, new ScenarioPath(true) {Tiles =
                    [
                    ScenarioPath.TileType.None,
                    ScenarioPath.TileType.Shield,
                    ScenarioPath.TileType.Shield,
                    ScenarioPath.TileType.Ring,
                    ScenarioPath.TileType.Shield,
                    ScenarioPath.TileType.Shield,
                    ScenarioPath.TileType.Ring,
                    ScenarioPath.TileType.DiceRoll,
                    ScenarioPath.TileType.Shield,
                    ScenarioPath.TileType.DiceRoll,
                    ScenarioPath.TileType.BigShield,
                    ]}
                },
                { PathType.Hiding, new ScenarioPath(false) {Tiles =
                    [
                    ScenarioPath.TileType.None,
                    ScenarioPath.TileType.Book,
                    ScenarioPath.TileType.Ring,
                    ScenarioPath.TileType.Heart,
                    ScenarioPath.TileType.Ring,
                    ScenarioPath.TileType.Heart,
                    ScenarioPath.TileType.Ring,
                    ScenarioPath.TileType.Heart,
                    ]}
                },
                { PathType.Traveling, new ScenarioPath(false) {Tiles =
                    [
                    ScenarioPath.TileType.Shield,
                    ScenarioPath.TileType.Shield,
                    ScenarioPath.TileType.Sun,
                    ScenarioPath.TileType.Shield,
                    ScenarioPath.TileType.Sun,
                    ScenarioPath.TileType.Shield,
                    ScenarioPath.TileType.Sun,
                    ]}
                }
            })
        {
        }
    }
}

using BvdR_Lib.Game.Acts;
using BvdR_Lib.Game.Priority.EventPriority;
using BvdR_Lib.Game.Prologs;
using BvdR_Lib.Game.Prologs.BagEnd;
using BvdR_Lib.Cards.ActivityCards;
using System.Text;
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
            new LinkedList<IScenarioEvent>() 
            {
                /*TODO create Events*/

            },
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


        public class MoriaEvent_1 : IScenarioEvent
        {
            public async void Start(GameController gameController)
            {
                await gameController.ChangeState(new GroupDiscardState(
                    gameController,
                    [BaseActivityCard.ActivityCardType.Friendship, BaseActivityCard.ActivityCardType.Joker],
                    (engine) => {
                        engine.MoveSauron(1);
                        return true;
                    }
                ));
            }
        }
        public class MoriaEvent_2 : IScenarioEvent
        {
            public async void Start(GameController gameController)
            {
                await gameController.ChangeState(new EachPlayerDiscardState(
                    gameController,
                    [BaseActivityCard.ActivityCardType.Hiding],
                    (engine,player) => {
                        player.RollDice();
                        return true;
                    }
                ));
            }
        }
        public class MoriaEvent_3 : IScenarioEvent
        {
            public async void Start(GameController gameController)
            {
                HobitCard card = gameController.DrawCard(1)[0];
                await gameController.ChangeState(new SpecificPlayerDiscardState(
                    gameController,
                    [card.Symbols[0], card.Symbols[0]],
                    engine =>
                    {
                        engine.MoveSauron(1);
                        return true;
                    },
                    gameController.GetCurrentPlayer(),
                    engine =>
                    {
                        //TODO Add boek
                        engine.GetCurrentPlayer().CardsInHand.Add(/*boek*/ new HobitCard(Cards.BaseCard.CardColor.None, BaseActivityCard.ActivityCardType.Hiding));
                        return true;
                    }
                ));
                gameController.ActController.CurrentAct.Current.TriggerEvent(gameController);
            }
        }
        public class MoriaEvent_4 : IScenarioEvent
        {
            public async void Start(GameController gameController)
            {
                if(gameController.ActController)
                    
            }
        }
    }
}

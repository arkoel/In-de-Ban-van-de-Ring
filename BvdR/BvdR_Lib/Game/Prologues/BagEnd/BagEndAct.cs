using BvdR_Lib.Game.Players;
using BvdR_Lib.Game.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Prologs.BagEnd
{
    public class BagEndAct : IPrologue
    {
        public List<IScenarioEvent> PrologueEvents { get; } = new List<IScenarioEvent>()
        {
            new BagEndEvent_1(),
        
        };


        public class BagEndEvent_1 : IScenarioEvent
        {
            public void Start(GameController gameController)
            {
                //All Players get 6 cards
                foreach(Player p in gameController.Players)
                {
                    p.DrawCards(6);
                }
            }
        }

        public class BagEndEvent_2 : IScenarioEvent
        {
            public async void Start(GameController gameController)
            {
                //ringbearer may roll to draw and devide 4 hobitcards
                if (!await gameController.UserInput.ChooseToRoll())
                    return;
                gameController.Ringbearer.RollDice();


            }
        }
        public class BagEndEvent_3 : IScenarioEvent
        {
            public void Start(GameController gameController)
            {
                //one player discards 2 Hide_cards or Sauron moves
            }
        }
    }
}

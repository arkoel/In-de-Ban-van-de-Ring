using BvdR_Lib.Cards;
using BvdR_Lib.Game.Players;
using BvdR_Lib.Game.Scenarios;

namespace BvdR_Lib.Game.Prologs.BagEnd
{
    public class BagEnd : IPrologue
    {
        public List<IScenarioEvent> PrologueEvents { get; private set; }

        public BagEnd()
        {
            PrologueEvents = new List<IScenarioEvent>()
            {
                new BagEndEvent_1(),
                new BagEndEvent_2(),
                new BagEndEvent_3(),
            };
        }

        public class BagEndEvent_1 : IScenarioEvent
        {
            public void Start(GameController gameController)
            {
                foreach (Player p in gameController.Players)
                {
                    p.CardsInHand.AddRange(gameController.DrawCard(6));
                }
            }
        }

        public class BagEndEvent_2 : IScenarioEvent
        {
            public async void Start(GameController gameController)
            {
                if (!await gameController.UserInput.ChooseToRoll())
                    return;
                gameController.Ringbearer.RollDice();
                BaseCard[] topCards = gameController.DrawCard(4);
                Player[] ChosenPlayers = [];
                while (ChosenPlayers.Length != 4)
                    ChosenPlayers = await gameController.UserInput.DevideCardsBetweenPlayers(topCards);
                for (int i = 0; i < 4; i++)
                {
                    ChosenPlayers[i].CardsInHand.Add(topCards[i]);
                }
            }
        }
        public class BagEndEvent_3 : IScenarioEvent
        {
            public async void Start(GameController gameController)
            {
                if (await gameController.UserInput.ChooseForAPlayerToDiscardTwoCards())
                {
                    Player playerToDiscard = await gameController.UserInput.ChoosePlayer(gameController.Players.ToArray());
                    if (playerToDiscard.CardsInHand.Count < 2)
                    {
                        gameController.GameOver();
                        return;
                    }
                    BaseCard[] chosenCards = await gameController.UserInput.ChooseCards(playerToDiscard.CardsInHand.ToArray(), 2);
                    if (!chosenCards.All(playerToDiscard.CardsInHand.Contains))
                    {
                        gameController.GameOver();
                        return;
                    }
                    playerToDiscard.CardsInHand.RemoveAll(chosenCards.Contains);
                    return;
                }
                gameController.MoveSauron(1);
            }
        }
    }
}

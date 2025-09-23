using BvdR_Lib;
using BvdR_Lib.Cards;
using BvdR_Lib.Game;
using BvdR_Lib.Game.Players;
using BvdR_Lib.Game.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_ConsoleInterface
{
    internal class ConsoleController : BvdR_Lib.BvdR_UserInput
    {
        public ConsoleController() { }

        Task<BaseCard[]> BvdR_UserInput.ChooseCards(BaseCard[] cards, int amount)
        {
            throw new NotImplementedException();
        }

        Task<bool> BvdR_UserInput.ChooseForAPlayerToDiscardTwoCards()
        {
            throw new NotImplementedException();
        }

        Task<Scenario.PathType> BvdR_UserInput.ChoosePath(Scenario.PathType[] paths)
        {
            throw new NotImplementedException();
        }

        Task<Player> BvdR_UserInput.ChoosePlayer(Player[] players)
        {
            throw new NotImplementedException();
        }

        Task<int> BvdR_UserInput.ChooseShield(int amountOfShields)
        {
            throw new NotImplementedException();
        }

        Task<bool> BvdR_UserInput.ChooseToRoll()
        {
            throw new NotImplementedException();
        }

        Task<Player[]> BvdR_UserInput.DevideCardsBetweenPlayers(BaseCard[] cards)
        {
            throw new NotImplementedException();
        }
    }
}

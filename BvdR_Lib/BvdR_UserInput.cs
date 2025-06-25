using BvdR_Lib.Cards;
using BvdR_Lib.Game.Players;
using BvdR_Lib.Game.Scenarios;

namespace BvdR_Lib
{
    public interface BvdR_UserInput
    {
        public Task<int> ChooseShield(int amountOfShields);
        public Task<Scenario.PathType> ChoosePath(Scenario.PathType[] paths);
        public Task<bool> ChooseToRoll();
        public Task<Player[]> DevideCardsBetweenPlayers(BaseCard[] cards);
        public Task<bool> ChooseForAPlayerToDiscardTwoCards();
        public Task<Player> ChoosePlayer(Player[] players);
        public Task<BaseCard[]> ChooseCards(BaseCard[] cards, int amount);
    }
}

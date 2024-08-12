using BvdR_Lib.Cards;
using BvdR_Lib.Cards.ActivityCards;
using BvdR_Lib.Game.Scenarios;

namespace BvdR_Lib.Game.Players
{
    public class Character_Frodo : Player
    {
        public override Scenario.PathType MapCardTypeToPathType(GameController gameController, BaseActivityCard.ActivityCardType type, BaseCard.CardColor color)
        {
            if (color == BaseCard.CardColor.White)
                return Scenario.PathType.AnyPath;
            return base.MapCardTypeToPathType(gameController, type, color);
        }
    }
}

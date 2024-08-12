using BvdR_Lib.Cards.ActivityCards;

namespace BvdR_Lib.Game.Players
{
    public class Character_Pippin : Player
    {
        public override bool CheckIfActivityCardCanBePlayed(BaseActivityCard card)
        {
            return (_amountOfCardsPlayed != 2);
        }
    }
}

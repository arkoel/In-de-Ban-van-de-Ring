using BvdR_Lib.Game;
using BvdR_Lib.Game.Players;

namespace BvdR_Lib.Cards
{
    public abstract class BaseCard
    {
        public CardColor Color { get; set; }

        public BaseCard(CardColor color)
        {
            Color = color;
        }

        public abstract void Play(GameController gameController);

        public enum CardColor
        {
            White,
            Gray,
            None
        }
    }
}

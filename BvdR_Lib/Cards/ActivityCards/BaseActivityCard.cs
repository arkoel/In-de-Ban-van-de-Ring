using BvdR_Lib.Game;
using BvdR_Lib.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Cards.ActivityCards
{
    public abstract class BaseActivityCard : BaseCard
    {
        public abstract ActivityCardType[] Symbols { get; }
        public BaseActivityCard(CardColor color) : base(color) { }
        public enum ActivityCardType
        {
            Friendship,
            Traveling,
            Hiding,
            Fighting,
            Joker,
            RollDie,
        }

    }
}

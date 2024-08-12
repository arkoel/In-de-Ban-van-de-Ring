using BvdR_Lib.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Cards.ActivityCards
{
    public class HobitCard : BaseActivityCard
    {
        public override ActivityCardType[] Symbols { get; }
        public HobitCard(CardColor color, ActivityCardType symbol) : base(color)
        {
            Symbols = [symbol];
        }

    }
}

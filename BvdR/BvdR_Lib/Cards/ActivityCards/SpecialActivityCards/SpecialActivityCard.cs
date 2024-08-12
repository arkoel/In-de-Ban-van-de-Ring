using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Cards.ActivityCards.SpecialActivityCards
{
    public class SpecialActivityCard : BaseActivityCard
    {
        public override ActivityCardType[] Symbols { get; }
        public SpecialActivityCard(CardColor color, ActivityCardType[] symbols) : base(color)
        {
            Symbols = symbols;
        }
        
    }
}

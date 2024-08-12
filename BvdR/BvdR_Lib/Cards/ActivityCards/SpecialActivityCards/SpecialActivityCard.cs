using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Cards.ActivityCards.SpecialActivityCards
{
    public class SpecialActivityCard : BaseActivityCard
    {
        List<ActivityCardType> Symbols { get; set; }
        public SpecialActivityCard(CardColor color, List<ActivityCardType> symbols) : base(color)
        {
            Symbols = symbols;
        }
    }
}

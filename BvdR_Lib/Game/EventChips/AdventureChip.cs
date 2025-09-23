using BvdR_Lib.Cards.ActivityCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.EventChips
{
    public class AdventureChip : IEventChip
    {
        public HobitCard.ActivityCardType CardType { get; set; }
        public void Play(GameController engine)
        {
            engine.MovePath(engine.MapCardTypeToPathType(CardType));
        }
    }
}

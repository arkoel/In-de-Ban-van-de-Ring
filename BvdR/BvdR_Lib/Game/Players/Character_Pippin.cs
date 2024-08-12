using BvdR_Lib.Cards.ActivityCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Players
{
    public class Character_Pippin: Player
    {
        public override bool CheckIfActivityCardCanBePlayed(BaseActivityCard card)
        {
            return (_amountOfCardsPlayed != 2);
        }
    }
}

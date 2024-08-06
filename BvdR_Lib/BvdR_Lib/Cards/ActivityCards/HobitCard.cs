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
        ActivityCardType Symbol { get; set; }
        public HobitCard(CardColor color, ActivityCardType symbol) : base(color)
        {
            Symbol = symbol;
        }

        public override async void Play(GameController gameController)
        {

            gameController.MovePath();
        }

    }
}

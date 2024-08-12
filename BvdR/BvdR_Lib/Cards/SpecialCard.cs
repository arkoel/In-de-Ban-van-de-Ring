using BvdR_Lib.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Cards
{
    public class SpecialCard : BaseCard
    {
        public SpecialCard() : base(CardColor.None) 
        {
        }
        public abstract void Play(GameController gameController);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Players
{
    public class Character_Fatty : Player
    {
        public override void EndScenario()
        {
            base.EndScenario();
            DrawTwoCards();
        }
    }
}

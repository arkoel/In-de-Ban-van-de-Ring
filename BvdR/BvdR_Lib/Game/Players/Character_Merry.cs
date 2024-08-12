using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Players
{
    public class Character_Merry : Player
    {
        public override void EndScenario()
        {
            //move over corruption trail for max(2 - [each different lifetoken],0)
        }
    }
}

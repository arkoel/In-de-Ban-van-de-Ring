using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.EventChips
{
    public interface IEventChip
    {
        public void Play(GameController engine);
    }
}

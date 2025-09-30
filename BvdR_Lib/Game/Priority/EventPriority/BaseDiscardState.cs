using BvdR_Lib.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Priority.EventPriority
{
    public class BaseDiscardState : BaseState
    {
        protected GameController engine;
        public BaseDiscardState(GameController _engine) 
        {
            engine = _engine;
        }
        private protected bool Discard()
        {
            if (ActionTaken)
                return false;
            ActionTaken = true;
            return true;
        }
    
    }
}

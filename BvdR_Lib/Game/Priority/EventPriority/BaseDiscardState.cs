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
        private GameController engine;
        private Func<GameController, bool> consequence;
        public BaseDiscardState(GameController _engine, Func<GameController, bool> _consequence) 
        {
            consequence = _consequence;
            engine = _engine;
        }
        private protected bool Discard()
        {
            if (ActionTaken)
                return false;
            ActionTaken = true;
            return true;
        }
        private protected void Consequence()
        {
            if(ActionTaken)
                return;
            ActionTaken = true;
            consequence.Invoke(engine);
        }
    }
}

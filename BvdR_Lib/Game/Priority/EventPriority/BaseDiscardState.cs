using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Priority.EventPriority
{
    public class BaseDiscardState : BaseState
    {        
        public BaseDiscardState() 
        {
        
        }
        public void Discard()
        {
            if (ActionTaken)
                return;
            ActionTaken = true;
        }
        public void Consequence()
        {
            if(ActionTaken)
                return;
            ActionTaken = true;
        }
    }
}

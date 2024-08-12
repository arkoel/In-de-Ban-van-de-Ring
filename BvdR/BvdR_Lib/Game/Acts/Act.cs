using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Acts
{
    public abstract class Act
    {
        public abstract bool IsScenario();
        public abstract void Start();
    }
}

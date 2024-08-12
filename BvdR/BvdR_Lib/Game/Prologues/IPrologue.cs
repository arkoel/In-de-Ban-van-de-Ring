using BvdR_Lib.Game.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Prologs
{
    public interface IPrologue
    {
        public List<IScenarioEvent> PrologueEvents { get; }
    }
}

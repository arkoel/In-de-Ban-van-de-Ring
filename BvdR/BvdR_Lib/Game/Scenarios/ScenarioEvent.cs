using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Scenarios
{
    public interface IScenarioEvent
    {
        public void Start(GameController gameController);
    }
}

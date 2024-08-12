﻿using BvdR_Lib.Game.Acts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib
{
    public interface BvdR_UserInput
    {
        public int ChooseShield(int amountOfShields);
        public ScenarioPath ChoosePath(ScenarioPath[] paths);
    }
}

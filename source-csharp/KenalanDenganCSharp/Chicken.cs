﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenalanDenganCSharp
{
    public class Chicken : Bird
    {
        public override int FingerCount { get { return 4; }}

        public override void Run()
        {
            base.Run();
        }

    }
}

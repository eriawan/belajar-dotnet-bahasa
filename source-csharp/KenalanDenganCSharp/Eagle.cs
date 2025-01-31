using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KenalanDenganCSharp
{
    public class Eagle : Bird
    {
        public Eagle()
        {
            
        }
        public override int FingerCount { get { return 5; } }

        public override void Run()
        {
            Console.WriteLine("Eagle is running");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenalanDenganCSharp
{
    public class Chicken : Bird
    {
        public string? WingColor { get; set; }

        private int tembolokCount;

        public int TembolokCount
        {
            get { return tembolokCount; }
            set { tembolokCount = value; }
        }


        public override int FingerCount { get { return 4; }}

        public override void Run()
        {
            base.Run();
        }

        public override void Sleep()
        {
            if (DateTime.Now.Year < 2025)
            {
                base.Sleep();
            }
            // overridden implementation on its own
        }

        public override void Hibernate()
        {
            base.Hibernate();
        }

    }
}

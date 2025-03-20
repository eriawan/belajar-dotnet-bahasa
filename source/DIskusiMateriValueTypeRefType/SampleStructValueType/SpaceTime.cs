using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIskusiMateriValueTypeRefType.SampleStructValueType
{
    public struct SpaceTime
    {
        public double XCoordinate { get; set; } = 0.0d;
        public double YCoordinate { get; set; } = 0.0d;
        public double ZCoordinate { get; set; } = 0.0d;
        public DateTime DateTimeEventCoordinate { get; set; }

        public SpaceTime()
        {
            
        }

    }
}

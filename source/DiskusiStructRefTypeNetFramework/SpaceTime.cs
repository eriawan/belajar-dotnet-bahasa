using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskusiStructRefTypeNetFramework
{
    public readonly struct SpaceTime
    {
        public double XCoordinate { get; }
        public double YCoordinate { get; }
        public double ZCoordinate { get; }
        public DateTime DateTimeEventCoordinate { get; }

        public SpaceTime(double xCoord, double yCoord, double zCoord, DateTime dateTimeEvent)
        {
            XCoordinate = xCoord;
            YCoordinate = yCoord;
            ZCoordinate = zCoord;
            DateTimeEventCoordinate = dateTimeEvent;
        }

    }
}

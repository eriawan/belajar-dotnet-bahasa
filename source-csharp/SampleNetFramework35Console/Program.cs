using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleNetFramework35Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Bird> birds = new List<Bird>();
            //birds.Add(new Chicken());
            //IEnumerable<Bird> birdsEnumerable = new List<Chicken>();
            Bird[] birdArray = new Bird[3];
            birdArray[0] = new Chicken();
        }
    }
}

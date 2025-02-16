using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleNetFramework48Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Bird> birds = new List<Bird>();
            birds.Add(new Chicken());
            IEnumerable<Bird> birdsEnumerable = new List<Chicken>();
        }
    }
}

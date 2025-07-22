using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.NetFX48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            pubsEntities pubs = new pubsEntities();
            var data = pubs.publishers.ToList();
            foreach (var item in data)
            {
                Console.WriteLine(item.pub_name);
            }
        }
    }
}

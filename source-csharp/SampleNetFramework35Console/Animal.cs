using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleNetFramework35Console
{
    public abstract class Animal
    {
        public bool CanFly { get; set; }
        public bool CanSwim { get; set; }

        public abstract string SkinColor { get; set; }

        public void Reproduce()
        {
            Console.WriteLine("Animal is reproducing");
        }

        public void Eat()
        {
            Console.WriteLine("Animal is eating");
        }

        public void Drink()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Sleep()
        { 
        }

        public abstract void Run();
    }
}

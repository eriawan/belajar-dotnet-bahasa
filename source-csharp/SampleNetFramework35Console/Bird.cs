using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleNetFramework35Console
{
    public class Bird : Animal
    {
        public override string SkinColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        public override void Sleep()
        {
            base.Sleep();
        }
    }
}

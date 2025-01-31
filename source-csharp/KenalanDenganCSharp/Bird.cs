namespace KenalanDenganCSharp
{
    public abstract class Bird : Animal
    {
        public override String? SkinColor { get; set; }

        public abstract int FingerCount { get; }

        public override void Run()
        {
            Console.WriteLine("Bird is running");
        }
    }
}
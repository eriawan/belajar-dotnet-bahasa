// See https://aka.ms/new-console-template for more information
using KenalanDenganCSharp;

Console.WriteLine("Hello, World!");

Animal eagle1 = new Eagle();
eagle1.Run();
((Bird)eagle1).Run();
Bird bird02 = (Bird)eagle1;
bird02.Run();
eagle1 = new Chicken();
Bird bird03 = new Chicken();
bird03.Run();

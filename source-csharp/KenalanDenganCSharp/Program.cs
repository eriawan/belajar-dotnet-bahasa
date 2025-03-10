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
//Chicken ayam01 = new Bird();
Fish catFish01 = new CatFish();

Animal[] animals = new Animal[] { new Eagle(), new Chicken(), new Fish() };
List<CatFish> list = new List<CatFish>();
//list.Add(new Fish());
list.Add(new CatFish());
Console.WriteLine(list.Count);
//list.Remove(catFish01);
Console.WriteLine(list.Count);

IComparer<CatFish> compareCatFish = new ComparerFish<CatFish>();
Fish ortunyaCatfish = new CatFish();
compareCatFish.Compare((CatFish)ortunyaCatfish, new CatFish());

ClassConstructorDenganParameter classConstructorDenganParameter = new ClassConstructorDenganParameter("testing");

List<Bird> birds = new List<Bird>();
birds.Add(new Chicken());
IEnumerable<Bird> birdsEnumerable = new List<Chicken>();
//Func<int, bool> cekGenap = (bilangan) => bilangan % 2 == 0;
//Func<int, bool> cekGenap = (bilangan) =>
//{
//    bilangan = bilangan + 0;
//    return (bilangan % 2 == 0);
//};
Func<int, bool> cekGenap = delegate(int bilangan) { return (bilangan % 2 == 0); };

//Action<int> tidur = (durasitidur) => System.Threading.Thread.Sleep(durasitidur);
//Action<int> tidur = (durasitidur) =>
//{
//    System.Threading.Thread.Sleep(durasitidur);
//};
Action<int> tidur = delegate(int durasitidur) { System.Threading.Thread.Sleep(durasitidur); };




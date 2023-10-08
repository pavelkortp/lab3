using ConsoleApp1;

Farmer farmer = new Farmer("Pablo", "Zhurbitskyi", "vegetables");
Farm farm = new Farm("Pablos`s farm", 6, farmer);

farm.AddPlant(new Tomato("Yellow tomato", 57, true,  0.4));
farm.AddPlant(new Tomato("Pink tomato", 55, true,  0.5));
farm.AddPlant(new Carrot("Small carrot", 90, true, Season.SPRING, 0.4, 2));
farm.AddPlant(new Carrot("Big carrot", 115, true, Season.SPRING, 0.4, 0.5));

foreach (var p in farm.PlantsOnGrowing)
{
    Console.WriteLine(p);
    Console.WriteLine("Can produce new crop:"+p.IsHarvest());
    Console.WriteLine();
}



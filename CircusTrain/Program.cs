using CircusTrain;


List<IAnimal> animals = new List<IAnimal>();

for (int i = 0; i < 0; i++)
{
    animals.Add(new PolarBear());
}
        
for (int i = 0; i < 0; i++)
{
    animals.Add(new Tiger());
}
        
for (int i = 0; i < 1; i++)
{
    animals.Add(new Monkey());
}
        
for (int i = 0; i < 2; i++)
{
    animals.Add(new Elephant());
}
        
for (int i = 0; i < 3; i++)
{
    animals.Add(new Zebra());
}
        
for (int i = 0; i < 0; i++)
{
    animals.Add(new Gecko());
}

Train train = new Train(animals);

for (int i = 0; i < train.Wagons.Length; i++)
{
    var wagon = train.Wagons[i];
            
    Console.WriteLine($"Wagon {i}: ");

    foreach (var animal in wagon.Animals)
    {
        Console.WriteLine($"Animal: C:{animal.IsCarnivore} S:{animal.Size}");
    }
                
    Console.WriteLine($"End of wagon {i}");
}
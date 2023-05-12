using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace CircusTrain;

public class Train
{
    public Wagon[] Wagons { get; }
    public const int WagonSize = 10;

    public Train(List<IAnimal> animals)
    {
        List<Wagon> wagons = new();

        //First fill with large carnivores
        IAnimal[] largeCarnivores = animals.Where(a => a.IsCarnivore && a.Size == AnimalSize.Large).ToArray();
        foreach (IAnimal animal in largeCarnivores)
        {
            wagons.Add(new Wagon(new[] { animal }));
            animals.Remove(animal);
        }

        //Medium Carnivoresen compatible 
        List<IAnimal> mediumCarnivores = animals.Where(a => a.IsCarnivore && a.Size == AnimalSize.Medium).ToList();
        List<IAnimal> compatibleWithMediumCarnivore =
            animals.Where(a => !a.IsCarnivore && a.Size == AnimalSize.Large).ToList();

        foreach (IAnimal animal in mediumCarnivores)
        {
            List<IAnimal> wagonList = new List<IAnimal>();

            wagonList.Add(animal);
            animals.Remove(animal);

            FillWagon(wagonList, compatibleWithMediumCarnivore, animals);

            wagons.Add(new Wagon(wagonList.ToArray()));
        }

        //Place all small carnivores first with 3 medium carnivores and then with any compatible animals.
        List<IAnimal> smallCarnivores = animals.Where(a => a.IsCarnivore && a.Size == AnimalSize.Small).ToList();
        List<IAnimal> compatibleWithSmallCarnivores = animals
            .Where(a => !a.IsCarnivore && (a.Size == AnimalSize.Large || a.Size == AnimalSize.Medium)).ToList();

        List<IAnimal> compatibleAndMediumSize = compatibleWithSmallCarnivores.Where(a => a.Size == AnimalSize.Medium).ToList();

        //First with 3 medium herbivores
        if (compatibleAndMediumSize.Count >= 3)
        {
            IAnimal smallCarnivore = smallCarnivores.First();

            IAnimal[] mediumHerbivores = compatibleAndMediumSize.Take(3).ToArray();

            List<IAnimal> animalList = new List<IAnimal>();
            animalList.Add(smallCarnivore);
            animalList.AddRange(mediumHerbivores);

            Wagon wagon = new Wagon(animalList.ToArray());
            wagons.Add(wagon);
            
            smallCarnivores.Remove(smallCarnivore);
            compatibleAndMediumSize.RemoveAll(a => mediumHerbivores.Contains(a));
            animals.RemoveAll(a => mediumHerbivores.Contains(a));
            animals.Remove(smallCarnivore);
        }

        //Any compatible animals
        foreach (IAnimal animal in smallCarnivores)
        {
            List<IAnimal> wagonList = new List<IAnimal>();
            
            wagonList.Add(animal);
            animals.Remove(animal);
            
            FillWagon(wagonList, compatibleWithSmallCarnivores, animals);

            Wagon wagon = new Wagon(wagonList.ToArray());

            wagons.Add(wagon);
        }
        
        //Place all large herbivores with 2 in 1 wagon
        List<IAnimal> largeHerbivores = animals.Where(a => !a.IsCarnivore && a.Size == AnimalSize.Large).ToList();

        while (largeHerbivores.Count >= 2)
        {
            IAnimal firstHerbivore = largeHerbivores.First();
            largeHerbivores.Remove(firstHerbivore);
            IAnimal secondHerbivore = largeHerbivores.First();

            animals.Remove(firstHerbivore);
            animals.Remove(secondHerbivore);
            
            wagons.Add(new Wagon(new []{firstHerbivore, secondHerbivore}));
        }
        
        //Fill any remaining wagons.
        while (animals.Count != 0)
        {
            List<IAnimal> wagonList = new List<IAnimal>();
            FillWagon(wagonList, animals, animals);
            wagons.Add(new Wagon(wagonList.ToArray()));
        }

        Wagons = wagons.ToArray();
    }

    private static void FillWagon(List<IAnimal> wagonList, List<IAnimal> compatibleWithMediumCarnivore, List<IAnimal> animals)
    {
        int pointsLeft = WagonSize - wagonList.Sum(a => (int)a.Size);

        while (pointsLeft != 0 && compatibleWithMediumCarnivore.Count != 0 && animals.Count != 0 && compatibleWithMediumCarnivore.Min(a => (int) a.Size) <= pointsLeft)
        {
            pointsLeft = WagonSize - wagonList.Sum(a => (int)a.Size);
            switch (pointsLeft)
            {
                case < 3:
                    IAnimal? animal1 = compatibleWithMediumCarnivore.FirstOrDefault(a => a.Size == AnimalSize.Small);
                    if (animal1 == null)
                    {
                        break;
                    }
                    wagonList.Add(animal1);
                    animals.Remove(animal1);
                    compatibleWithMediumCarnivore.Remove(animal1);
                    break;
                case < 5:
                    IAnimal? animal2 = compatibleWithMediumCarnivore.FirstOrDefault(a => a.Size == AnimalSize.Medium);
                    if (animal2 == null)
                    {
                        animal2 = compatibleWithMediumCarnivore.FirstOrDefault(a => a.Size == AnimalSize.Small);
                        if (animal2 == null)
                        {
                            break;
                        }
                    }

                    wagonList.Add(animal2);
                    animals.Remove(animal2);
                    compatibleWithMediumCarnivore.Remove(animal2);
                    break;
                case >= 5:
                    IAnimal? animal3 = compatibleWithMediumCarnivore.FirstOrDefault(a => a.Size == AnimalSize.Large);
                    if (animal3 == null)
                    {
                        animal3 = compatibleWithMediumCarnivore.FirstOrDefault(a => a.Size == AnimalSize.Medium);
                        if (animal3 == null)
                        {
                            animal3 = compatibleWithMediumCarnivore.FirstOrDefault(a => a.Size == AnimalSize.Small);
                            if (animal3 == null)
                            {
                                break;
                            }
                        }
                    }

                    wagonList.Add(animal3);
                    animals.Remove(animal3);
                    compatibleWithMediumCarnivore.Remove(animal3);
                    break;
            }

            pointsLeft = WagonSize - wagonList.Sum(a => (int)a.Size);
        }
    }
}
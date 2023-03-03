namespace CircusTrain;

public class Wagon
{
    public Wagon(IAnimal[] animals, int maxPoints = 10)
    {
        if (animals.Sum(a=>(int) a.Size) > 10)
        {
            throw new InvalidOperationException("Animal points were too high");
        }

        IAnimal[] carnivores = animals.Where(a => a.IsCarnivore).ToArray();
        IAnimal[] herbivores = animals.Where(a => !a.IsCarnivore).ToArray();

        int largestCarnivore = carnivores.Any() ? carnivores.Max(a => (int)a.Size) : 0;

        int smallestHerbivore = herbivores.Any() ? herbivores.Min(a => (int)a.Size) : 6;

        if (largestCarnivore >= smallestHerbivore)
        {
            throw new InvalidOperationException("Animals will eat each other");
        }
        
        Animals = animals;
        MaxPoints = maxPoints;
    }

    public IAnimal[] Animals { get; }
    public int MaxPoints { get; }
}
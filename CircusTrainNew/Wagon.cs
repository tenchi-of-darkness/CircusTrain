namespace CircusTrainNew;

public class Wagon
{
    public Wagon(Animal[] animals, int maxPoints = 10)
    {
        if (animals.Sum(a=>(int) a.Size) > 10)
        {
            throw new InvalidOperationException("Animal points were too high");
        }

        Animal[] carnivores = animals.Where(a => a.IsCarnivore).ToArray();
        Animal[] herbivores = animals.Where(a => !a.IsCarnivore).ToArray();

        int largestCarnivore = carnivores.Any() ? carnivores.Max(a => (int)a.Size) : 0;

        int smallestHerbivore = herbivores.Any() ? herbivores.Min(a => (int)a.Size) : 0;

        if (largestCarnivore >= smallestHerbivore)
        {
            throw new InvalidOperationException("Animals will eat each other");
        }
        
        Animals = animals;
        MaxPoints = maxPoints;
    }

    public Animal[] Animals { get; }
    public int MaxPoints { get; }
}
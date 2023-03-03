namespace CircusTrainNew;

public class Train
{
    public Wagon[] Wagons { get; }
    public const int WagonSize = 10;

    public Train(Animal[] animals)
    {
        List<Wagon> wagons = new();
        Animal[] largeCarnivores = animals.Where(a => a.IsCarnivore && a.Size==AnimalSize.Large).ToArray();
        foreach (Animal animal in largeCarnivores)
        {
            wagons.Add(new Wagon(new []{animal}));
        }
        
        Animal[] mediumCarnivores = animals.Where(a => a.IsCarnivore && a.Size==AnimalSize.Medium).ToArray();
        Animal[] compatibleWithMediumCarnivore = animals.Where(a => !a.IsCarnivore && a.Size==AnimalSize.Large).ToArray();
        
        foreach (Animal animal in mediumCarnivores)
        {
            List<Animal> wagonList = new List<Animal>();
            
            wagonList.Add(animal);
            while (wagonList.Sum(a=>(int)a.Size) < 10)
            {
                int pointsLeft = WagonSize - wagonList.Sum(a => (int)a.Size);
                if ((int)compatibleWithMediumCarnivore.Min(a => a.Size) <= pointsLeft)
                {
                   
                }
                wagonList.Add(compatibleWithMediumCarnivore.First());
            }
            
        }
    }

    public List<Animal> GetList()
    {
        
    }
}
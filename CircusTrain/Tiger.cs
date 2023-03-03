namespace CircusTrain;

public class Tiger : IAnimal
{
    public bool IsCarnivore { get; } = true;
    public AnimalSize Size { get; } = AnimalSize.Medium;
}
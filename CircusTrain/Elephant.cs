namespace CircusTrain;

public class Elephant : IAnimal
{
    public bool IsCarnivore { get; } = false;
    public AnimalSize Size { get; } = AnimalSize.Large;
}
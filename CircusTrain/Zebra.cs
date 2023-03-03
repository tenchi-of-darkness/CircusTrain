namespace CircusTrain;

public class Zebra : IAnimal
{
    public bool IsCarnivore { get; } = false;
    public AnimalSize Size { get; } = AnimalSize.Medium;
}
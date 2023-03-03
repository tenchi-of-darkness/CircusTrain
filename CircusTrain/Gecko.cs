namespace CircusTrain;

public class Gecko : IAnimal
{
    public bool IsCarnivore { get; } = false;
    public AnimalSize Size { get; } = AnimalSize.Small;
}
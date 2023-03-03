namespace CircusTrain;

public class Monkey : IAnimal
{
    public bool IsCarnivore { get; } = true;
    public AnimalSize Size { get; } = AnimalSize.Small;
}
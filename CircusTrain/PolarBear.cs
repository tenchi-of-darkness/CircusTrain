namespace CircusTrain;

public class PolarBear : IAnimal
{
    public bool IsCarnivore { get; } = true;
    public AnimalSize Size { get; } = AnimalSize.Large;
}
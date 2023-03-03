using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Helpers;

namespace CircusTrain.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData(0, 0, 1, 2, 3, 0, 2)]
    [InlineData(0, 0, 1, 1, 2, 5, 2)]
    [InlineData(1, 1, 1, 1, 1, 1, 4)]
    [InlineData(1, 1, 2, 1, 5, 1, 5)]
    [InlineData(0, 0, 1, 2, 1, 1, 2)]
    [InlineData(0, 0, 3, 3, 2, 0, 3)]
    [InlineData(3, 3, 7, 6, 5, 0, 13)]
    public void TestTrain(int largeCarnivore, int mediumCarnivore, int smallCarnivore, int largeHerbivore,
        int mediumHerbivore, int smallHerbivore, int amountOfWagons)
    {
        //Arrange
        List<IAnimal> animals = new List<IAnimal>();

        for (int i = 0; i < largeCarnivore; i++)
        {
            animals.Add(new PolarBear());
        }
        
        for (int i = 0; i < mediumCarnivore; i++)
        {
            animals.Add(new Tiger());
        }
        
        for (int i = 0; i < smallCarnivore; i++)
        {
            animals.Add(new Monkey());
        }
        
        for (int i = 0; i < largeHerbivore; i++)
        {
            animals.Add(new Elephant());
        }
        
        for (int i = 0; i < mediumHerbivore; i++)
        {
            animals.Add(new Zebra());
        }
        
        for (int i = 0; i < smallHerbivore; i++)
        {
            animals.Add(new Gecko());
        }

        //Act
        Train train = new Train(animals);
        
        //Assert
        Assert.Equal(amountOfWagons, train.Wagons.Length);
    }
}

public class WagonTest
{
    [Fact]
        public void Wagon_SizeIsEleven_ThrowException(){
            List<IAnimal> geckos = new List<IAnimal>();
            for(int i=0;i<11;i++){
                
                geckos.Add(new Gecko());
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => new Wagon(geckos.ToArray()));
        }
    }

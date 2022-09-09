namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void NameSetterShouldWorkCorrectly()
        {
            var fish = new Fish("Gosho");
            fish.Name = "New Name";
            Assert.That(fish.Name, Is.EqualTo("New Name"));
        }

        [Test]
        public void AvailibleSetterShouldWorkCorrectly()
        {
            var fish = new Fish("Gosho");
            fish.Available = false;
            Assert.That(fish.Available, Is.EqualTo(false));
        }

        [TestCase("")]
        [TestCase(null)]
        public void InvalidAquariumNameShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var aquarium = new Aquarium(name, 12);
            },
            nameof(name), "Invalid aquarium name!");
        }

        [Test]
        public void AquariumNameShouldBeSet()
        {
            var aquarium = new Aquarium("Aqua", 12);

            Assert.That("Aqua", Is.EqualTo(aquarium.Name));
        }

        [Test]
        public void NegativeCapacityShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var aquarium = new Aquarium("Aqua", -1);
            },
            "Invalid aquarium capacity!");
        }

        [Test]
        public void AquariumCapacityShouldBeSet()
        {
            var aquarium = new Aquarium("Aqua", 12);

            Assert.That(12, Is.EqualTo(aquarium.Capacity));
        }

        [Test]
        public void CountReturnsTheCountOfTheCollection()
        {
            var aquarium = new Aquarium("Aqua", 5);
            Assert.That(0, Is.EqualTo(aquarium.Count));
        }

        [Test]
        public void AddShouldAddFishToTheCollection()
        {
            var aquarium = new Aquarium("Aqua", 5);

            aquarium.Add(new Fish("Borko"));
            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddingFishInFullAquariumThrowsException()
        {
            var aquarium = new Aquarium("Aqua", 5);
            aquarium.Add(new Fish("Borko"));
            aquarium.Add(new Fish("Borko"));
            aquarium.Add(new Fish("Borko"));
            aquarium.Add(new Fish("Borko"));
            aquarium.Add(new Fish("Borko"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(new Fish("Borko"));
            }
            , "Aquarium is full!");
        }

        [Test]
        public void RemoveFishShouldRemoveTheFirstFishWithTheGivenName()
        {
            var aquarium = new Aquarium("Aqua", 5);
            aquarium.Add(new Fish("Borko"));
            aquarium.Add(new Fish("Pesho"));
            aquarium.RemoveFish("Borko");

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveFishWithInvalidFishNameShouldThrowAnException()
        {
            var aquarium = new Aquarium("Aqua", 5);
            aquarium.Add(new Fish("Borko"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Invalid");
            },
            "Fish with the name Invalid doesn't exist!");
        }

        [Test]
        public void SellFishShouldSellFishAndMakeItUnavailible()
        {
            var aquarium = new Aquarium("Aqua", 5);
            aquarium.Add(new Fish("Borko"));

            var fish = aquarium.SellFish("Borko");
            Assert.IsTrue(!fish.Available);
        }

        [Test]
        public void SellFishWithInvalidNameThrowsAnException()
        {
            var aquarium = new Aquarium("Aqua", 5);
            aquarium.Add(new Fish("Borko"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("Invalid");
            },
            "Fish with the name Invalid doesn't exist!");
        }

        [Test]
        public void ReportShouldGiveTheInfoInSpecificFormat()
        {
            const string expectedReport = "Fish available at Aqua: Borko, Pepi";

            //Arrange
            var aquarium = new Aquarium("Aqua", 5);
            aquarium.Add(new Fish("Borko"));
            aquarium.Add(new Fish("Pepi"));

            //Act
            string report = aquarium.Report();

            //Assert
            Assert.That(report, Is.EqualTo(expectedReport));
        }
    }
}

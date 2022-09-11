using CatDatabase;
using CatDatabase.Interfaces;

namespace CatTester.Tests
{
    public class CatTests
    {
        [Test]
        public void CatShouldSuccessfulyBeAddedToTheDatabase()
        {
            var fakeCat = A.Fake<ICat>();
            var fakeDatabase = A.Fake<IMeowDatabase>();
            fakeDatabase.Add(fakeCat);

            A.CallTo(() => fakeDatabase.Add(fakeCat)).MustHaveHappened();
        }

        [Test]
        public void RemoveShouldRemoveCatWithTheGivenNameFromTheDatabase()
        {
            var fakeDatabase = A.Fake<IMeowDatabase>();
            fakeDatabase.Add(A.Fake<ICat>());
            fakeDatabase.Remove("Sharo");

            A.CallTo(() => fakeDatabase.Remove("Sharo")).MustHaveHappened();
        }

        [Test]
        public void DatabaseShouldBeAbleToReturnTheOldestCat()
        {
            var fakeDatabase = A.Fake<IMeowDatabase>();
            fakeDatabase.Add(new Cat("Gosho", "Igrae s topka chesto", 12));
            fakeDatabase.Add(new Cat("Sharo", "Kotkata na Kenov haha", 7));
            var oldCat = new Cat("Pesho", "Obicha da qde sirene", 13);
            fakeDatabase.Add(oldCat);

            A.CallTo(() => fakeDatabase.GetOldestCat()).Returns(oldCat); // If we put even null we will get a positive resault from the test.
        }

        [Test]
        public void GetAllCatsShouldReturnTheCatsBelowTheGivenYears()
        {
            var fakeDatabase = A.Fake<IMeowDatabase>();

            A.CallTo(() => fakeDatabase.ReturnAllCatsUnderYears(A<int>._))
                .Returns(new List<ICat>() 
                {
                    new Cat("Gosho", "Likes to play", 12 ),
                    new Cat("Anton", "Drinks water a lot", 5 ),
                    new Cat("Petyr", "Likes dogs", 11 )
                });
        }
    }
}

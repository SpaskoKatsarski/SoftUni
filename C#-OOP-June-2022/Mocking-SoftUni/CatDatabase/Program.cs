using CatDatabase;

MeowDatabase database = new MeowDatabase(new Cat("Sharo", "Meraci za lekcii", 7), new Cat("Gosho", "Mnogo strahliv", 3));
foreach (var cat in database)
{
    Console.WriteLine(cat);
}

database.Remove("Sharo");
database.Add(new Cat("DAS", "DASASD", 123));
Console.WriteLine();

MyMethod("Stop");
MyMethod(12.2m);

static void MyMethod<T>(T val)
{
    Console.WriteLine("Generic method returns value type: " + val.GetType().Name);
}

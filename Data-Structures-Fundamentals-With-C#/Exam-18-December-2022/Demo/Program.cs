using Exam.ViTube;

ViTubeRepository repo = new ViTubeRepository();

repo.RegisterUser(new User("1", "Pesho"));

IEnumerable<User> passiveUsers = repo.GetPassiveUsers();

Console.WriteLine(passiveUsers.Count());
// See https://aka.ms/new-console-template for more information

using MatchmakingSystem;

class Program
{
    private static readonly string[] Habits = {"打球", "跳舞", "唱歌", "看電影", "慢跑", "寫程式", "吃飯", "睡覺", "寫作", "讀書", "數學"};
    private static readonly Random Random = new Random();
    private static readonly int NumberOfIndividuals = 30;

    public static void Main(string[] args)
    {
        List<Individual> individuals = new List<Individual>();

        // Create and add individuals to the list
        for (int i = 0; i < NumberOfIndividuals; i++)
        {
            var newIndividual = new Individual(i + 1,
                Random.Next(2) == 0 ? "MALE" : "FEMALE",
                Random.Next(50) + 18,
                "intro", RandomHabits(),
                new Coord(Random.Next(2000), Random.Next(2000)));
            individuals.Add(newIndividual);
            
            string habitsString = string.Join(", ", newIndividual.Habits);

            Console.WriteLine($"Id: {newIndividual.Id}, Gender: {newIndividual.Gender}, Age: {newIndividual.Age}, " +
                              $"Intro: {newIndividual.Intro}, Habits: [{habitsString}], CoordX: {newIndividual.Coord.X}, " +
                              $"CoordY: {newIndividual.Coord.Y}");
        }

        // Matching based on distance
        MatchingApp app = new MatchingApp(individuals, new DistanceBasedMatching());
        Individual firstIndividual = individuals[0];
        app.Match();
        Console.WriteLine($"距離：{firstIndividual.Coord.Distance(firstIndividual.Matched.Coord)}");

        // Changing strategy to habit based matching
        app.MatchingStrategy = new HabitBasedMatching();
        app.Match();
        Console.WriteLine($"共同興趣：{string.Join(", ", Intersection(firstIndividual.Habits, firstIndividual.Matched.Habits))}");

        app.MatchingStrategy = new Reversed(new DistanceBasedMatching());
        app.Match();
        Console.WriteLine($"反向距離：{firstIndividual.Coord.Distance(firstIndividual.Matched.Coord)}");
        
        app.MatchingStrategy = new Reversed(new HabitBasedMatching());
        app.Match();
        Console.WriteLine($"反向共同興趣：{string.Join(", ", Intersection(firstIndividual.Habits, firstIndividual.Matched.Habits))}");
    }

    public static HashSet<string> RandomHabits()
    {
        int size = Random.Next(Habits.Length) + 1;
        List<string> habitList = Habits.OrderBy(_ => Random.Next()).ToList();
        return new HashSet<string>(habitList.Take(size));
    }

    private static IEnumerable<string> Intersection(HashSet<string> set1, HashSet<string> set2)
    {
        return set1.Intersect(set2);
    }
}
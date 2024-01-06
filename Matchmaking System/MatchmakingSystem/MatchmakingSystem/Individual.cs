namespace MatchmakingSystem;

public class Individual
{
    public readonly int Id;
    public readonly string Gender;
    public readonly int Age;
    public readonly string Intro;
    public readonly HashSet<string> Habits;
    public readonly Coord Coord;
    private Individual matched;

    public Individual(int id, string gender, int age, string intro, HashSet<string> habits, Coord coord)
    {
        Id = id;
        Gender = gender;
        Age = age;
        Intro = intro;
        Habits = habits;
        Coord = coord;
    }

    public Individual Matched => matched;

    public void Match(Individual other)
    {
        if (other == this)
        {
            throw new InvalidOperationException("Must not match one to himself.");
        }
        matched = other;
    }
}
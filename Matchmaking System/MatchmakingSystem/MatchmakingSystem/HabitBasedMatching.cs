namespace MatchmakingSystem;

public class HabitBasedMatching : IMatchingStrategy
{
    public List<Individual> Match(Individual individual, List<Individual> candidates)
    {
        return candidates.OrderByDescending(c => IntersectionSize(c.Habits, individual.Habits))
            .ToList();
    }

    private int IntersectionSize(HashSet<string> set1, HashSet<string> set2)
    {
        return set1.Intersect(set2).Count();
    }
}
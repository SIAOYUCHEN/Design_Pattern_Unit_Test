namespace MatchmakingSystem;

public class DistanceBasedMatching : IMatchingStrategy
{
    public List<Individual> Match(Individual individual, List<Individual> candidates)
    {
        return candidates.OrderBy(c => individual.Coord.Distance(c.Coord))
            .ThenBy(c => c.Id)
            .ToList();
    }
}
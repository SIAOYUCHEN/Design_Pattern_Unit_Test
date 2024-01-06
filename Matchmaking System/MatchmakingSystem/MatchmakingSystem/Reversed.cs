namespace MatchmakingSystem;

public class Reversed : IMatchingStrategy
{
    private readonly IMatchingStrategy matchingStrategy;

    public static Reversed ReversedStrategy(IMatchingStrategy matchingStrategy)
    {
        return new Reversed(matchingStrategy);
    }

    public Reversed(IMatchingStrategy matchingStrategy)
    {
        this.matchingStrategy = matchingStrategy;
    }

    public List<Individual> Match(Individual individual, List<Individual> candidates)
    {
        List<Individual> result = matchingStrategy.Match(individual, candidates);
        result.Reverse();
        return result;
    }
}
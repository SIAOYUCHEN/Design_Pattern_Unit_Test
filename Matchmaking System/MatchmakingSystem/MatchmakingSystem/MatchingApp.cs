namespace MatchmakingSystem;

public class MatchingApp
{
    private readonly List<Individual> individuals;
    private IMatchingStrategy matchingStrategy;

    public MatchingApp(List<Individual> individuals, IMatchingStrategy matchingStrategy)
    {
        this.individuals = individuals;
        this.matchingStrategy = matchingStrategy;
    }

    public void Match()
    {
        foreach (var individual in individuals)
        {
            var candidates = individuals.Where(i => i != individual).ToList();
            var result = matchingStrategy.Match(individual, candidates);
            individual.Match(result.First());
        }
    }

    public IMatchingStrategy MatchingStrategy
    {
        get => matchingStrategy;
        set => matchingStrategy = value;
    }
}
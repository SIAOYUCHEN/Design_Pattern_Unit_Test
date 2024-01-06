namespace MatchmakingSystem;

public interface IMatchingStrategy
{
    List<Individual> Match(Individual individual, List<Individual> candidates);
}
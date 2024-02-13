using System.Text;

namespace AdapterV1;

public class Word
{
    public string Spelling { get; }
    public Dictionary<PartOfSpeech, List<string>> Definitions { get; }

    public Word(string spelling, Dictionary<PartOfSpeech, List<string>> definitions)
    {
        Spelling = spelling;
        Definitions = definitions;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append($"{Spelling}: \n");

        foreach (var entry in Definitions)
        {
            foreach (var description in entry.Value)
            {
                builder.AppendLine($"{entry.Key}: {description}");
            }
        }

        return builder.ToString();
    }

    public enum PartOfSpeech
    {
        Noun = 1,
        Pronoun,
        Verb,
        Adv,
        Adj,
        Article,
        Preposition,
        Conjunction,
        Interjection
    }
}